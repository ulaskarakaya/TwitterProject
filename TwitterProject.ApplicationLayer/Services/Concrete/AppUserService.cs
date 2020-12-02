using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Models.VMs;
using TwitterProject.ApplicationLayer.Services.Abstraction;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.DomainLayer.Repositories.Abstraction;
using TwitterProject.DomainLayer.UnitofWork.Abstraction;

namespace TwitterProject.ApplicationLayer.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IFollowService _followService;
        public AppUserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IFollowService followService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _followService = followService;
        }
        public async Task DeleteUser(params object[] parameters)
        {
            await _unitOfWork.ExecuteSqlRaw("spDeleteUsers {0}", parameters);
        }

        public async Task EditUser(EditProfileDto model)
        {
            var user = await _unitOfWork.AppUser.GetById(model.Id);
            if (user != null)
            {
                if (model.Image != null)
                {
                    using var image = Image.Load(model.Image.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save("wwwroot/images/users/" + user.UserName + ".jpg");
                    user.ImagePath = ("/images/users/" + user.UserName + ".jpg");
                    _unitOfWork.AppUser.Update(user);
                    await _unitOfWork.Commit();
                }
                if (model.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    await _userManager.UpdateAsync(user);
                }
                if (model.UserName != user.UserName)
                {
                    var isUserNameExist = await _userManager.FindByNameAsync(model.UserName);
                    if (isUserNameExist == null)
                    {
                        await _userManager.SetUserNameAsync(user, model.UserName);
                        user.UserName = model.UserName;
                        await _signInManager.SignInAsync(user, isPersistent: true);
                    }
                }
                if (model.Name != user.Name)
                {
                    user.Name = model.Name;
                    _unitOfWork.AppUser.Update(user);
                    await _unitOfWork.Commit();
                }
                if (model.Email != user.Email)
                {
                    var isEmailExist = await _userManager.FindByNameAsync(model.Email);

                }
            }
        }

        public AuthenticationProperties ExternalLogin(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        public Task<SignInResult> ExternalLoginSignIn(string provider, string key)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ExternalRegister(ExternalLoginInfo info, ExternalLoginDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<EditProfileDto> GetById(int id)
        {
            var user = await _unitOfWork.AppUser.GetById(id);

            return _mapper.Map<EditProfileDto>(user);
        }

        public async Task<ProfileSummaryDto> GetByName(string UserName)
        {
            var user = await _unitOfWork.AppUser.GetFilteredFirstorDefault(
                selector: y => new ProfileSummaryDto
                {
                    UserName = y.UserName,
                    ImagePath = y.ImagePath,
                    TweetCount = y.Tweets.Count,
                    FollowersCount = y.Followers.Count,
                    FollowingsCount = y.Following.Count
                },
                predicate: x => x.UserName == UserName);

            return user;
        }

        public async Task<ExternalLoginInfo> GetExternalLoginInfo()
        {
            return await _signInManager.GetExternalLoginInfoAsync();
        }

        public Task<SignInResult> Login(LoginDto model)
        {
            throw new NotImplementedException();
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> Register(RegisterDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SearchUserDto>> SearchUser(string keyword, int pageIndex)
        {
            var users = await _unitOfWork.AppUser.GetFilteredList(
                selector: x => new SearchUserDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    ImagePath = x.ImagePath
                },
                predicate: x => x.UserName.Contains(keyword) || x.Name.Contains(keyword),
                pageIndex: pageIndex,
                pageSize: 10);

            return users;
        }
    

        public Task<List<FollowListVm>> UserFollowers(int id, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public Task<List<FollowListVm>> UserFollowings(int id, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public Task<int> UserIdFromName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
