namespace HatDieu.Infrastructure;

public class Constants
{
    public class Policy
    {
        public const string Admin = "Admin";
        public const string Reader = "Read";
        public const string Writer = "Write";
    }
    
    public class Scope
    {
        public const string Admin = "microservices.data-crawler.payrix.admin";
        public const string Read = "microservices.data-crawler.payrix.read";
        public const string Write = "microservices.data-crawler.payrix.write";
    }
    
    public class TokenManagement
    {
        public const string DataCrawlerPayrixWithAllScopes = "DataCrawlerPayrixWithAllScopes";
    }
}