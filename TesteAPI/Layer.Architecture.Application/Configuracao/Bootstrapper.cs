using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Infra.Data.Repository;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architeture.Configuracao
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IRotaService, RotaService>();

            //Repositories
            services.AddScoped<IRotaRepository, RotaRepository>();
        }
    }
}
