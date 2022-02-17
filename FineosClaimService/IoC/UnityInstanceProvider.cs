using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Unity;

namespace WcfServiceApplication.DependencyInjection.WCF
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        public UnityInstanceProvider()
            : this(null) { }

        public UnityInstanceProvider(Type type)
        {
            ServiceType = type;
            Container = new UnityContainer();
        }

        public IUnityContainer Container { get; set; }

        public Type ServiceType { get; set; }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return Container.Resolve(ServiceType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance) { }
    }
}