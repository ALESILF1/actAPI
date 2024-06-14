using Layer.Architecture.Infra.Data.Context;
using Layer.Architeture.Configuracao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;


namespace Layer.Architecture.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapperSetup();

            services.AddHttpClient<ApplicationAuthenticationClient>();
            services.AddDependencyInjectionSetup();
            //services.AddIdentityConfig(Configuration);

            services.AddSwaggerConfig();

            //services.AddHubDb(Configuration);

            services.AddDbContext<MyContext>(options =>
            {
                var server = Configuration["database:sqlserver:server"];
                var database = Configuration["database:sqlserver:database"];
                var username = Configuration["database:sqlserver:username"];
                var password = Configuration["database:sqlserver:password"];
                options.UseSqlServer($"Data Source={server};Database={database};User Id={username};Password={password}", opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.DefaultModelsExpandDepth(-1); // esconde schema no final da pagina
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "API FINANCIAMENTO ALESILF");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
