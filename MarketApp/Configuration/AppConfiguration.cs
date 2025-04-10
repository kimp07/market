using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Unity.Interception.Utilities;

namespace MarketApp.Configuration
{
    public class AppConfiguration
    {
        public void InitContainer()
        {
            var container = new Dictionary<Type, Type>();

            var assemblies = Assembly.GetExecutingAssembly().GetTypes();
            AppendComponents(container, [.. assemblies.Where(t => t.IsClass && t.GetCustomAttributes(typeof(Bean), true).Length > 0)]);
            ;
        }

        private void AppendComponents(Dictionary<Type, Type> container, List<Type> types)
        {
            types.ForEach(type =>
            {
                type.GetInterfaces()
                .Where(t => t.GetCustomAttributes(typeof(Component), true).Length > 0)
                .ToList()
                .ForEach(i =>
                {
                    try
                    {
                        container.Add(i, type);
                    }
                    catch (System.Exception)
                    {
                        throw new System.Exception("Can't register component " + i.FullName);
                    }
                });
            }
            );
        }
    }

}