using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;

namespace TwitterProject.ApplicationLayer.Services.Abstraction
{
    public interface IFollowService
    {
        Task Follow(FollowDto model);
        Task UnFollow(FollowDto model);
        Task<bool> isFollowing(FollowDto model);
        Task<List<int>> FollowingList(int id);
        Task<List<int>> FollowerList(int id);
    }
}
