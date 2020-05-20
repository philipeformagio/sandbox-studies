using KissLog;
using KissLog.Apis.v1.Listeners;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreIdentity.Config
{
    public class LogConfig
    {
        public static void RegisterKissLogListeners(IConfiguration _configuration)
        {
            KissLogConfiguration.Listeners.Add(new KissLogApiListener(
                _configuration["KissLog.OrganizationId"],
                _configuration["KissLog.ApplicationId"],
                _configuration["KissLog.Environment"]
            ));
        }
    }
}
