namespace SimpleIdentity.Services.Contracts
{
    using SimpleIdentity.Models.Contracts;
    using System.Collections.Generic;
    public interface IAccountService
    {
        void LoginUser(string userName, string password);

        void AddUser(string userName, string password);
    }
}
