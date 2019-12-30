using System;
using Microsoft.Extensions.DependencyInjection;

namespace StaticDependencyInjection
{
    /// <summary>
    /// Mark this service as a singleton service.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SingletonServiceAttribute : ServiceAttribute
    {
        public SingletonServiceAttribute() : base(null, null, ServiceLifetime.Singleton, true)
        {
        }
    }

    /// <summary>
    /// Mark this service as a singleton service interface and specify an implementation type.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SingletonServiceWithImplAttribute : ServiceAttribute
    {
        public SingletonServiceWithImplAttribute(Type implType) : base(implType, null, ServiceLifetime.Singleton, true)
        {
        }
    }

    /// <summary>
    /// Mark this service as a singleton service implementation and specify an interface type.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SingletonServiceAsAttribute : ServiceAttribute
    {
        public SingletonServiceAsAttribute(Type serviceType) : base(null, serviceType, ServiceLifetime.Singleton,
            true)
        {
        }
    }
}