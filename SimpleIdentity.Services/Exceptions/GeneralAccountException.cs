namespace SimpleIdentity.Services.Exceptions
{
    using System;
    public class GeneralAccountException : ApplicationException
    {
        public GeneralAccountException(string message)
            : base(message)
        {
        }
    }
}
