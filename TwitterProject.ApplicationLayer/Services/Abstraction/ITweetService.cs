using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Models.VMs;

namespace TwitterProject.ApplicationLayer.Services.Abstraction
{
    public interface ITweetService
    {
        Task<List<TimeLineVm>> GetTimeLine(int userId, int pageIndex);
        Task AddTweet(SendTweetDto model);
        Task<TweetDetailVm> TweetDetail(int id, int userId);
        Task<List<TimeLineVm>> UserTweets(string userName, int id, int pageIndex);
        Task DeleteTweet(int id, int userId);
    }
}
