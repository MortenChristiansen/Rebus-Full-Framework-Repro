using Repro.Rebus;

namespace Repro
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RebusSetup.ConfigureRebus();
        }
    }
}
