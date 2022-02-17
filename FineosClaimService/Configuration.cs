using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FineosClaimService
{
    public class Configuration : IConfiguration
    {
        private readonly ConnectionStringSettingsCollection _connectionStrings;
        private readonly NameValueCollection _appSettings;

        public Configuration()
        {
            _connectionStrings = ConfigurationManager.ConnectionStrings;
            _appSettings = ConfigurationManager.AppSettings;
        }

        public string ServiceBusConnectionString => _appSettings["ServiceBusConnectionString"];

        public string ClaimRequestQeueName => _appSettings["ClaimRequestQeueName"];

        public string ClaimRequestTopicEndPoint => _appSettings["ClaimRequestTopicEndPoint"];

        public string ClaimRequestTopicAccessKey => _appSettings["ClaimRequestTopicAccessKey"];
    }
}