using System;
using Microsoft.Extensions.DependencyInjection;

namespace StaticDependencyInjection
{
    /// <summary>
    /// Mark this service as a transient service.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TransientServiceAttribute : ServiceAttribute
    {
        public TransientServiceAttribute() : base(null, null, ServiceLifetime.Transient, true)
        {
        }
    }

    /// <summary>
    /// Mark this service as a transient service interface and specify an implementation type.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TransientServiceWithImplAttribute : ServiceAttribute
    {
        public TransientServiceWithImplAttribute(Type implType) : base(implType, null, ServiceLifetime.Transient, true)
        {
        }
    }

    /// <summary>
    /// Mark this service as a transient service implementation and specify an interface type.
    /// Has no effect if the service type has already been registered to service collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TransientServiceAsAttribute : ServiceAttribute
    {
        public TransientServiceAsAttribute(Type interfaceType) : base(null, interfaceType, ServiceLifetime.Transient,
            true)
        {
        }
    }
}