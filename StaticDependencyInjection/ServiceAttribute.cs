using System;
using Microsoft.Extensions.DependencyInjection;

namespace StaticDependencyInjection
{
    public abstract class ServiceAttribute : Attribute
    {
        public Type ImplType { get; }
        public Type InterfaceType { get; }
        public ServiceLifetime LifeTime { get; }
        public bool Weak { get; }

        protected ServiceAttribute(Type implType, Type interfaceType, ServiceLifetime lifeTime, bool weak)
        {
            ImplType = implType;
            InterfaceType = interfaceType;
            LifeTime = lifeTime;
            Weak = weak;
        }
    }
}