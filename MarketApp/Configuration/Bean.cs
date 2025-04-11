using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.Configuration
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Bean : System.Attribute
    {
        private readonly Scope scope;

        public Bean()
        {
            this.scope = Scope.SCOPED;
        }

        public Bean(Scope scope)
        {
            this.scope = scope;
        }

    }
}