using MAGUS.Domain.Models;
using MAGUS.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAGUS.AspIdentityMongoDB
{

    public class IdentityFacade : IDisposable, IIdentityFacade
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public IdentityFacade(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser appUser, string password)
        {
            IdentityUser user = new IdentityUser() { UserName = appUser.UserName, EmailAddress = appUser.EmailAddress };

            var result = await _userManager.CreateAsync(user, password);

            return result;
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser appUser)
        {
            IdentityUser user = new IdentityUser() { UserName = appUser.UserName, EmailAddress = appUser.EmailAddress };

            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<SignInStatus> SignIn(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, true, false);
            return result;
        }

        public async Task SignInAsync(ApplicationUser appUser, bool isPersistent, bool rememberBrowser)
        {
            IdentityUser user = new IdentityUser() { UserName = appUser.UserName, EmailAddress = appUser.EmailAddress };

            await _signInManager.SignInAsync(user, isPersistent, rememberBrowser);
        }

        public async Task<bool> VerifyCode()
        {
            var result = await _signInManager.HasBeenVerifiedAsync();

            return result;
        }

        public async Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool rememberMe, bool rememberBrowser)
        {
            var result = await _signInManager.TwoFactorSignInAsync(provider, code, rememberMe, rememberBrowser);
            return result;
        }

        public async Task<IList<string>> GetCodeAsync()
        {
            var userId = await _signInManager.GetVerifiedUserIdAsync();

            if (userId == null) return null;

            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(userId);
            return userFactors;
        }

        public async Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent)
        {
            var result = await _signInManager.ExternalSignInAsync(loginInfo, isPersistent);
            return result;
        }

        public async Task<bool> SendTwoFactorCodeAsync(string provider)
        {
            var result = await _signInManager.SendTwoFactorCodeAsync(provider);
            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string Id, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(Id, login);
            return result;
        }

        void IDisposable.Dispose()
        {
            if (_userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            if (_signInManager != null)
            {
                _signInManager.Dispose();
                _signInManager = null;
            }
        }
    }
}
