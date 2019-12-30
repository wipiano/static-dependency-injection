using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace StaticDependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services in the assembly that marked by *ServiceAttribute.
        /// </summary>
        public static IServiceCollection AddStaticServices(this IServiceCollection services, Assembly targetAssembly)
        {
            var targets = targetAssembly.GetTypes()
                .Select(t => (type: t, attr: t.GetCustomAttributes().OfType<ServiceAttribute>().FirstOrDefault()));

            foreach (var (type, attr) in targets)
            {
                var descriptor =
                    ServiceDescriptor.Describe(attr.ServiceType ?? type, attr.ImplType ?? type, attr.LifeTime);

                if (attr.Weak)
                {
                    services.TryAdd(descriptor);
                }
                else
                {
                    services.Add(descriptor);
                }
            }

            return services;
        }
    }
}