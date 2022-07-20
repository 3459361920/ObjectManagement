using System;
using System.Collections.Generic;
using System.Text;

namespace Wathet.Common
{
    public class APIMConfig
    {
        public string ManagementApiUrl { get; set; }
        public string GroupName { get; set; }
        public string ServiceName { get; set; }
        public APIMCredentials Credentials { get; set; }
        public APIMClient ClientInfo { get; set; }
        public ApplicationInsightConfig ApplicationInsightConfig { get; set; }
    }

    public class APIMCredentials
    {
        public string SubscriptionId { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
        public string Identifier { get; set; }
    }
    public class APIMClient
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Resource { get; set; }
        public string TenantId { get; set; }
        public string Location { get; set; }
    }

    public class ApplicationInsightConfig
    {
        public string DefaultWorkSpacesId { get; set; }
        public string DefaultWorkSpacesName { get; set; }
    }
}
