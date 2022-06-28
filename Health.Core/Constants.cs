namespace Health.Core
{
    public static class Constants
    {
        public static class Configuration
        {
            public static class Identity
            {
                public static class Roles
                {
                    public static readonly string Admin = "Admin";
                    public static readonly string PartnerAdmin = "PartnerAdmin";
                    public static readonly string Customer = "Customer";
                }

                public static class Claims
                {
                    public static readonly string UserId = "UserId";
                    public static readonly string PartnerId = "PartnerId";
                }
            }
        }
        public static class Cache
        {
            public static readonly string LocaleResourcesCacheKey = "WSI.Core.LocaleResources-page:{0}-take:{1}-filter:{2}-filters:{3}";
            public static readonly string MetaData = "WSI.Core.MetaData.{0}.{1}";
            public static readonly string DynamicPriceEnabled = "WSI.Core.MetaData.DynamicPricing";
            public static readonly string EventsWSSToken = "WSI.Core.EventsWSSToken";

            public static class Permissions
            {
                public static readonly string PermissionsAllowedCacheKey = "WSI.permission.allowed-{0}-{1}";
            }

            public static class Vehicles
            {
                public static readonly string LastSynthesisSyncDate = "WSI.vehicles.LastSynthesisSyncDate";
            }
        }

    }
}
