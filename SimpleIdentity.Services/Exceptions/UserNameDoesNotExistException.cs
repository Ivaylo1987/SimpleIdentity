namespace SimpleIdentity.Services.Exceptions
{
    using System;
    public class UserNameDoesNotExistException : GeneralAccountException
    {
        public UserNameDoesNotExistException(string message)
            : base(message)
        {
        }
    }
}
