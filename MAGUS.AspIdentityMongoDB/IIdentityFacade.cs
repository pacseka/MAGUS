using System.Threading.Tasks;
using MAGUS.Domain.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace MAGUS.AspIdentityMongoDB
{
    public interface IIdentityFacade
    {
        Task<IdentityResult> CreateUser(ApplicationUser appUser, string password);
        Task<SignInStatus> SignIn(string email, string password);
        Task<bool> VerifyCode();
        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);
        Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser);
        Task<IList<string>> GetCodeAsync();
        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent);
        Task<bool> SendTwoFactorCodeAsync(string selectedProvider);
        Task<IdentityResult> CreateUser(ApplicationUser user);
        Task<IdentityResult> AddLoginAsync(string id, UserLoginInfo login);
    }
}