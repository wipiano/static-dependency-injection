using System;
using Microsoft.Extensions.DependencyInjection;

namespace StaticDependencyInjection
{
    public abstract class ServiceAttribute : Attribute
    {
        public Type ImplType { get; }
        public Type ServiceType { get; }
        public ServiceLifetime LifeTime { get; }
        public bool Weak { get; }

        protected ServiceAttribute(Type implType, Type serviceType, ServiceLifetime lifeTime, bool weak)
        {
            ImplType = implType;
            ServiceType = serviceType;
            LifeTime = lifeTime;
            Weak = weak;
        }
    }
}