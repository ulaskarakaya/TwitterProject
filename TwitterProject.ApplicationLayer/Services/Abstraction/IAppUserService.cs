using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterProject.ApplicationLayer.Models.DTOs;
using TwitterProject.ApplicationLayer.Models.VMs;

namespace TwitterProject.ApplicationLayer.Services.Abstraction
{
    public interface IAppUserService
    {
        Task DeleteUser(params object[] parameters);
        Task<IdentityResult> Register(RegisterDto model);
        Task<SignInResult> Login(LoginDto model);
        Task LogOut();
        Task<int> UserIdFromName(string username);
        AuthenticationProperties ExternalLogin(string provider, string redirectUrl);
        Task<ExternalLoginInfo> GetExternalLoginInfo();
        Task<SignInResult> ExternalLoginSignIn(string provider, string key);
        Task<IdentityResult> ExternalRegister(ExternalLoginInfo info, ExternalLoginDto model);
        Task<EditProfileDto> GetById(int id);
        Task EditUser(EditProfileDto model);
        Task<ProfileSummaryDto> GetByName(string UserName);
        Task<List<FollowListVm>> UserFollowings(int id, int pageIndex);
        Task<List<FollowListVm>> UserFollowers(int id, int pageIndex);
        Task<List<SearchUserDto>> SearchUser(string keyword, int pageIndex);
    }
}
