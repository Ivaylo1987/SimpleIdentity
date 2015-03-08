namespace SimpleIdentity.Services.Exceptions
{
    using System;
    public class UnableToSignUpException : GeneralAccountException
    {
        public UnableToSignUpException(string message)
            : base(message)
        {
        }
    }
}
