using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketApp.Configuration;

namespace MarketApp.Services
{
    [Bean]
    public class NewService : INewService
    {
        public string GetMessage()
        {
            return "Hello";
        }
    }
}