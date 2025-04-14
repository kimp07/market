using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketApp.Configuration;


namespace MarketApp.Services
{
    [Component(Scope.SINGLETON)]
    public interface INewService
    {
        String GetMessage();        
    }
}