namespace SimpleIdentity.Web.Infrastructure.Cache
{
    using System;
    using System.Web;

    public abstract class BaseCacheService
    {
        protected T GetByCacheId<T>(string cacheId, Func<T> getItemCallback) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;

            if (item == null)
            {
                this.PopulateCache<T>(cacheId, getItemCallback);
            }

            return item;
        }

        protected void ClearCache(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }


        protected void PopulateCache<T>(string cacheId, Func<T> getItemCallback)
        {
            var item = getItemCallback();
            HttpContext.Current.Cache.Insert(cacheId, item);
        }
    }
}