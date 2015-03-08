namespace SimpleIdentity.Web.App_Start
{
    using SimpleIdentity.Parsers;
    using SimpleIdentity.Web.Infrastructure.Cache;
    using System.Web.Hosting;
    public class InMemoryCacheConfig
    {

        public static void RegisterChace()
        {
            var pathToUsersFile = HostingEnvironment.MapPath("~/App_Data/users.xml");
            var memoryCacheService = new AppMemoryCacheService(new XElementUserParser(pathToUsersFile));
            memoryCacheService.PopulateCacheItem("Users");
        }
    }
}