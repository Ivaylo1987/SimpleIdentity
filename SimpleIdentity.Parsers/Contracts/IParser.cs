namespace SimpleIdentity.Parsers.Contracts
{
    using SimpleIdentity.Models.Contracts;
    using System.Collections.Generic;
    public interface IParser<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T user);
    }
}
