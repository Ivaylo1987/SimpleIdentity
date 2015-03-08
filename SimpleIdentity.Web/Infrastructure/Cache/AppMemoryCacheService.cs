namespace SimpleIdentity.Web.Infrastructure.Cache
{
    using SimpleIdentity.Models.Contracts;
    using SimpleIdentity.Parsers.Contracts;
    using SimpleIdentity.Services.Contracts;

    using System;
    using System.Collections.Generic;

    public class AppMemoryCacheService : BaseCacheService, ICacheService
    {
        private IParser<IUser> parser;

        public AppMemoryCacheService(IParser<IUser> parser)
        {
            this.parser = parser;
        }


        public IEnumerable<IUser> Users
        {
            get
            {
                return this.GetByCacheId("Users", () => this.parser.GetAll());
            }
        }

        public void ClearCacheItem(string cacheId)
        {
            this.ClearCache(cacheId);
        }

        public void PopulateCacheItem(string cacheId)
        {
            this.PopulateCache(cacheId, () => this.parser.GetAll());
        }
    }
}