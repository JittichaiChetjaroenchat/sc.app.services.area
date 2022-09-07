namespace SC.App.Services.Area.Common.Constants
{
    public class AppSettings
    {
        public class Applications
        {
            public class Area
            {
                public const string Name = "Applications:Area:Name";
            }
        }

        public class Culture
        {
            public const string Default = "Culture:Default";

            public const string Supports = "Culture:Supports";
        }

        public class Databases
        {
            public class Area
            {
                public const string ConnectionString = "Databases:Area:ConnectionString";
            }
        }

        public class ElasticSearch
        {
            public const string Uri = "ElasticSearch:Uri";
        }

        public class Cache
        {
            public const string Configuration = "Cache:Configuration";

            public const string CacheTime = "Cache:CacheTime";
        }
    }
}