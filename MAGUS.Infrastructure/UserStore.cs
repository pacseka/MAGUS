using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MongoDB.Driver;
using MAGUS.Model;

namespace MAGUS.Infrastructure
{
    public class UserStore : IUserStore<IdentityUser>,
        IUserLoginStore<IdentityUser, string>,
        IUserEmailStore<IdentityUser>,
        IUserLockoutStore<IdentityUser, string>,
        IUserTwoFactorStore<IdentityUser, string>,
        IUserPasswordStore<IdentityUser, string>
    {

        private IMongoCollection<IdentityUser> _collection;

        public UserStore(ApplicationDbContext context)
        {
            _collection = context.Collection<IdentityUser>();
        }

        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            user.LoginInfo.Add(login);
            return _collection.ReplaceOneAsync<IdentityUser>(x => x.Id == user.Id, user);
        }

        public Task CreateAsync(IdentityUser user)
        {
            return _collection.InsertOneAsync(user);
        }

        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            return _collection.Find<IdentityUser>(x => x.LoginInfo.Any(p => p.LoginProvider == login.LoginProvider && p.ProviderKey == login.ProviderKey)).FirstOrDefaultAsync();
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            return _collection.Find<IdentityUser>(x => x.EmailAddress == email).FirstOrDefaultAsync();
        }

        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            return _collection.Find<IdentityUser>(x => x.Id == userId).SingleOrDefaultAsync();
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            return _collection.Find<IdentityUser>(x => x.UserName == userName).SingleOrDefaultAsync();
        }

        public Task<int> GetAccessFailedCountAsync(IdentityUser user)
        {
            return Task.FromResult(user.LoginAttempt);
        }

        public Task<string> GetEmailAsync(IdentityUser user)
        {
            return Task.FromResult<string>(user.EmailAddress);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(IdentityUser user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            return Task.FromResult<bool>(!String.IsNullOrEmpty(user.Password));
        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            user.LoginAttempt++;
            return Task.FromResult(user.LoginAttempt);
        }

        public Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(IdentityUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityUser user)
        {
            return _collection.FindOneAndReplaceAsync<IdentityUser>(x => x.Id == user.Id, user);
        }
    }
}