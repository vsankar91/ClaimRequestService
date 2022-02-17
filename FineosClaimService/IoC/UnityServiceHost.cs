using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Unity;

namespace FineosClaimService.IoC
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses) { }

        public IUnityContainer Container
        {
            get { return DIWrapper.Container; }
        }

        protected override void OnOpening()
        {
            new UnityServiceBehavior(Container).AddToHost(this);
            base.OnOpening();
        }
    }
}