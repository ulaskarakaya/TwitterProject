using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.ColorSpaces;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Models.VMs;
using TwitterProject.ApplicationLayer.Services.Abstraction;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.UnitofWork.Abstraction;

namespace TwitterProject.ApplicationLayer.Services.Concrete
{
    public class TweetService : ITweetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFollowService _followService;
        private readonly IAppUserService _appUserService;
        public TweetService(IUnitOfWork unitOfWork, IMapper mapper, IFollowService followService, IAppUserService appUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _followService = followService;
            _appUserService = appUserService;
        }
        public async Task AddTweet(SendTweetDto model)
        {
            if (model.Image != null)
            {
                using var image = Image.Load(model.Image.OpenReadStream());
                if (image.Width !> 600)
                {
                    image.Mutate(x => x.Resize(600, 0));
                    Guid name = Guid.NewGuid();
                    image.Save("wwwroot/images/tweets/" + name + ".jpg");
                    model.ImagePath = ("/images/tweets/" + name + ".jpg");
                }
                var tweet = _mapper.Map<SendTweetDto, Tweet>(model);
                await _unitOfWork.Tweet.Add(tweet);
                await _unitOfWork.Commit();
            }
        }

        public async Task DeleteTweet(int id, int userId)
        {
            var tweet = await _unitOfWork.Tweet.FirstOrDefault(x => x.Id == id);
            if (userId == tweet.AppUserId)
            {
                _unitOfWork.Tweet.Delete(tweet);
                await _unitOfWork.Commit();
            }
        }

        public async Task<List<TimeLineVm>> GetTimeLine(int userId, int pageIndex)
        {
            List<int> followings = await _followService.FollowingList(userId);
            var tweets = await _unitOfWork.Tweet.GetFilteredList(
                selector: x => new TimeLineVm
                {
                    Id = x.Id,
                    Text = x.Text,
                    ImagePath = x.ImagePath,
                    AppUserId = x.AppUserId,
                    LikeCounts = x.Likes.Count,
                    MentionsCounts = x.Mentions.Count,
                    ShareCounts = x.Shares.Count,
                    CreateDate = x.CreateDate,
                    UserName = x.AppUser.UserName,
                    UserImage = x.AppUser.ImagePath,
                    isLiked = x.Likes.Any(y => y.AppUserId == userId)
                },
                orderBy: x=> x.OrderByDescending(y => y.CreateDate),
                predicate: x=> followings.Contains(x.AppUserId),
                include: x=> x.Include(z => z.AppUser).ThenInclude(z => z.Followers).Include(z => z.Likes),
                pageIndex: pageIndex
                );
            return tweets;
        }

        public Task<TweetDetailVm> TweetDetail(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TimeLineVm>> UserTweets(string userName, int id, int pageIndex)
        {
            throw new NotImplementedException();
        }
    }
}
