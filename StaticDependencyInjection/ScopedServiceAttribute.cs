using System;
using Microsoft.Extensions.DependencyInjection;

namespace StaticDependencyInjection
{
    /// <summary>
    /// Mark this service as a scoped service.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ScopedServiceAttribute : ServiceAttribute
    {
        public ScopedServiceAttribute() : base(null, null, ServiceLifetime.Scoped, true)
        {
        }
    }

    /// <summary>
    /// Mark this service as a scoped service interface and specify an implementation type.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ScopedServiceWithImplAttribute : ServiceAttribute
    {
        public ScopedServiceWithImplAttribute(Type implType) : base(implType, null, ServiceLifetime.Scoped, true)
        {
        }
    }

    /// <summary>
    /// Mark this service as a scoped service implementation and specify an interface type.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ScopedServiceAsAttribute : ServiceAttribute
    {
        public ScopedServiceAsAttribute(Type interfaceType) : base(null, interfaceType, ServiceLifetime.Scoped,
            true)
        {
        }
    }
}