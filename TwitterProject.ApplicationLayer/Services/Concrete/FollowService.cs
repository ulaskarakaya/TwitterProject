using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Services.Abstraction;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.UnitofWork.Abstraction;

namespace TwitterProject.ApplicationLayer.Services.Concrete
{
    public class FollowService : IFollowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FollowService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Follow(FollowDto model)
        {
            var isExsistFollow = await _unitOfWork.Follow.FirstOrDefault(x => x.FollowerId == model.FollowerId && x.FollowingId == model.FollowingId);
            if (isExsistFollow == null)
            {
                var follow = _mapper.Map<FollowDto, Follow>(model);
                await _unitOfWork.Follow.Add(follow);
                await _unitOfWork.Commit();
            }
        }

        public async Task<List<int>> FollowerList(int id)
        {
            var followerList = await _unitOfWork.Follow.GetFilteredList(
               selector: y => y.FollowerId,
               predicate: x => x.FollowerId == id);

            return followerList;
        }

        public async Task<List<int>> FollowingList(int id)
        {
            var followingList = await _unitOfWork.Follow.GetFilteredList(
                selector: y => y.FollowingId,
                predicate: x => x.FollowingId == id);
            return followingList;
        }

        public async Task<bool> isFollowing(FollowDto model)
        {
            var isExistFollow = await _unitOfWork.Follow.Any(x => x.FollowerId == model.FollowerId && x.FollowingId == model.FollowingId);
            return isExistFollow;
        }

        public async Task UnFollow(FollowDto model)
        {
            var isExsistFollow = await _unitOfWork.Follow.FirstOrDefault(x => x.FollowerId == model.FollowerId && x.FollowingId == model.FollowingId);
            _unitOfWork.Follow.Delete(isExsistFollow);
            await _unitOfWork.Commit();
        }
    }
}
