using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Unity;
using WcfServiceApplication.DependencyInjection.WCF;

namespace FineosClaimService.IoC
{
    public class UnityServiceBehavior : IServiceBehavior
    {
        private ServiceHost serviceHost;

        public UnityServiceBehavior()
        {
            InstanceProvider = new UnityInstanceProvider();
        }

        public UnityServiceBehavior(IUnityContainer unity)
        {
            InstanceProvider = new UnityInstanceProvider();
            InstanceProvider.Container = unity;
        }

        public UnityInstanceProvider InstanceProvider { get; set; }

        public void AddBindingParameters(
                ServiceDescription serviceDescription,
                ServiceHostBase serviceHostBase,
                Collection<ServiceEndpoint> endpoints,
                BindingParameterCollection bindingParameters)
        { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cdb in serviceHostBase.ChannelDispatchers)
            {
                var cd = cdb as ChannelDispatcher;
                if (cd != null)
                {
                    foreach (var ed in cd.Endpoints)
                    {
                        InstanceProvider.ServiceType = serviceDescription.ServiceType;
                        ed.DispatchRuntime.InstanceProvider = InstanceProvider;
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        public void AddToHost(ServiceHost host)
        {
            if (serviceHost != null)
            {
                return;
            }

            host.Description.Behaviors.Add(this);
            serviceHost = host;
        }
    }
}