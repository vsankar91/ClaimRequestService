using CommonServiceLocator;
using FineosClaimService.DataAccess;
using FineosClaimService.IoC;
using FineosClaimService.Repositories;
using FineosClaimService.Repositories.Interfaces;
using FineosClaimService.Services;
using FineosClaimService.Services.Interfaces;
using FineosClaimService.Tasks;
using FineosClaimService.Tasks.Interfaces;
using System;
using System.Web;
using Unity;
using Unity.ServiceLocation;

namespace FineosClaimService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //https://jamesheppinstall.wordpress.com/2012/06/20/windows-communication-foundation-resolving-wcf-service-dependencies-with-unity/
            ConfigureUnity();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        private void ConfigureUnity()
        {
            // Configure common service locator to use Unity
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(DIWrapper.Container));

            // Register the repository
            DIWrapper.Container.RegisterType(typeof(IClaimRequestRepository), typeof(ClaimRequestRepository));
            DIWrapper.Container.RegisterType(typeof(FineosClaimsDBContext), typeof(FineosClaimsDBContext));

            DIWrapper.Container.RegisterType(typeof(IServiceBusMessagingService), typeof(ServiceBusMessagingService));
            DIWrapper.Container.RegisterType(typeof(IClaimRequestService), typeof(ClaimRequestService));
            DIWrapper.Container.RegisterType(typeof(IEventGridService), typeof(EventGridService));

            DIWrapper.Container.RegisterType(typeof(IClaimRequestTask), typeof(ClaimRequestTask));

            DIWrapper.Container.RegisterType(typeof(IConfiguration), typeof(Configuration));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}