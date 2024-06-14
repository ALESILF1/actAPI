using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architeture.Configuracao
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            Bootstrapper.RegisterServices(service);
        }
    }
}
