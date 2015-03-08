namespace SimpleIdentity.Services.Contracts
{
    using SimpleIdentity.Models.Contracts;
    using System;
    using System.Collections.Generic;
    public interface ICacheService
    {
        IEnumerable<IUser> Users { get; }

        void ClearCacheItem(string cacheId);

        void PopulateCacheItem(string cacheId);
    }
}