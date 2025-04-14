using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Unity.Interception.Utilities;

namespace MarketApp.Configuration
{
    public class AppConfiguration
    {

        private AppConfiguration() { }

        private void InitContainer(IServiceCollection container)
        {

            var assemblies = Assembly.GetExecutingAssembly().GetTypes();
            RegisterServices(container, [.. assemblies.Where(t => t.IsClass && t.GetCustomAttributes(typeof(Bean), true).Length > 0)]);

        }

        private void RegisterServices(IServiceCollection container, List<Type> types)
        {
            types.ForEach(type =>
                type.GetInterfaces()
                .Where(t =>
                    t.GetCustomAttributes(typeof(Component), true).Length > 0
                    )
                .ToList()
                .ForEach(service => RegisterService(container, type, service))
            );

        }

        private void RegisterService(IServiceCollection container, Type implementation, Type service)
        {
            Component? component = service.GetCustomAttribute<Component>();
            if (component != null)
            {
                switch (component.GetScope())
                {
                    case Scope.TRANSIENT:
                        container.AddTransient(service, implementation);
                        break;
                    case Scope.SINGLETON:
                        container.AddSingleton(service, implementation);
                        break;
                    case Scope.SCOPED:
                        container.AddScoped(service, implementation);
                        break;
                    default:
                        throw new System.ArgumentException("Invalid components scope " + service.Name);
                }
            }
        }

        public static void ConfigureDiContainer(IServiceCollection container)
        {
            AppConfiguration configuration = new AppConfiguration();
            configuration.InitContainer(container);
        }

    }

}