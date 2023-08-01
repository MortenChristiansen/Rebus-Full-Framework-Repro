using Azure.Identity;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Config;
using System.Configuration;

namespace Repro.Rebus
{
    public static class RebusSetup
    {
        private static IBus _bus;

        public static void ConfigureRebus()
        {
            using (var activator = new BuiltinHandlerActivator())
            {
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                var tenantId = ConfigurationManager.AppSettings["TenantId"];

                var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
                {
                    ExcludeSharedTokenCacheCredential = true,
                    ExcludeAzureCliCredential = true,
                    ExcludeEnvironmentCredential = true,
                    ExcludeInteractiveBrowserCredential = true,
                    ExcludeManagedIdentityCredential = false,
                    ExcludeVisualStudioCodeCredential = true,
                    ExcludeVisualStudioCredential = false,
                    VisualStudioTenantId = tenantId
                });

                activator.Register((ct) => new RebusEventHandler(ct));

                _bus = Configure.With(activator)
                    .Transport(t => t.UseAzureServiceBus(connectionString, "rebus-queue", credential))
                    .Start();
            }
        }
    }
}