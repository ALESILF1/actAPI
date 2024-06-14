using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace Layer.Architeture.Configuracao
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup (this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            service.AddAutoMapper(typeof(AutoMapper));
        }
    }
}
