namespace SimpleIdentity.Services.Exceptions
{
    using System;
    public class IncorrectUsernamePasswordException : GeneralAccountException
    {
        public IncorrectUsernamePasswordException(string message)
            : base(message)
        {
        }
    }
}
