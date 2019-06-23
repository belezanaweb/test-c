using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoCConfig
{
    public class IoCConstructor
    {
        private static IoCConstructor _constructor;

        private IoCConstructor()
        {

        }

        public static IoCConstructor Instance()
        {
            if (_constructor == null)
                _constructor = new IoCConstructor();
            return _constructor;
        }

        public void ConfigureIoC(IServiceCollection svc)
        {
            
        }
    }
}
