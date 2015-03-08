namespace SimpleIdentity.Services
{
    using SimpleIdentity.Models;
    using SimpleIdentity.Models.Contracts;
    using SimpleIdentity.Parsers.Contracts;
    using SimpleIdentity.Services.Contracts;
    using SimpleIdentity.Services.Exceptions;
    using System.Collections.Generic;
    using System.Linq;

    public class CacheAccountService : IAccountService
    {
        private IParser<IUser> parser;
        private ICacheService cache;
        private IEnumerable<IUser> users;

        public CacheAccountService(IParser<IUser> parser, ICacheService cache)
        {
            this.parser = parser;
            this.cache = cache;
            users = cache.Users;
        }

        public void LoginUser(string userName, string password)
        {
            if (!this.DoesUserExist(userName))
            {
                throw new UserNameDoesNotExistException("Username does not exist");
            }

            var user = this.FindUserByUserName(userName);
            if (!IsPasswordCorrect(user, password))
            {
                throw new IncorrectUsernamePasswordException("Incorrect username/password");
            }
        }

        public void AddUser(string userName, string password)
        {
            if (this.DoesUserExist(userName))
            {
                throw new UnableToSignUpException("Unable to sign up");
            }

            var user = this.CreateUser(userName, password);
            this.ReInitializeCache();
        }

        private bool DoesUserExist(string userName)
        {
            var user = this.FindUserByUserName(userName);
            return user != null;
        }

        private IUser FindUserByUserName(string userName)
        {
            var user = this.users.FirstOrDefault(u => u.UserName == userName);
            return user;
        }

        private bool IsPasswordCorrect(IUser user, string password)
        {
            return user.Password == password;
        }

        private User CreateUser(string userName, string password)
        {
            var user = new User() { UserName = userName, Password = password };
            this.parser.Add(user);
            return user;
        }

        private void ReInitializeCache()
        {
            this.cache.ClearCacheItem("Users");
            this.cache.PopulateCacheItem("Users");
        }
    }
}
