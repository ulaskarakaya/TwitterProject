using AutoMapper;
using System;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Services.Abstraction;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.UnitofWork.Abstraction;

namespace TwitterProject.ApplicationLayer.Services.Concrete
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Like(LikeDto model)
        {
            var isLiked = await _unitOfWork.Like.FirstOrDefault(x => x.AppUserId == model.AppUserId && x.TweetId == model.TweetId);
            if (isLiked == null)
            {
                var like = _mapper.Map<LikeDto, Like>(model);
                await _unitOfWork.Like.Add(like);
                await _unitOfWork.Commit();
            }
        }

        public async Task Unlike(LikeDto model)
        {
            var isLiked = await _unitOfWork.Like.FirstOrDefault(x => x.AppUserId == model.AppUserId && x.TweetId == model.TweetId);
            _unitOfWork.Like.Delete(isLiked);
            await _unitOfWork.Commit();
        }
    }
}
