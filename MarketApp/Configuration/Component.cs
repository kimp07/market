using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.Configuration
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class Component : System.Attribute
    {
        private readonly Scope scope;

        public Component()
        {
            this.scope = Scope.SCOPED;
        }

        public Component(Scope scope)
        {
            this.scope = scope;
        }

        public Scope GetScope()
        {
            return scope;
        }

    }
}