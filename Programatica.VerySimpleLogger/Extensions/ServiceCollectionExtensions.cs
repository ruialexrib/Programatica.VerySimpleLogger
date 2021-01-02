using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Programatica.VerySimpleLogger.Adapters;
using Programatica.VerySimpleLogger.Data.Migrations.Context;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Context;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Mvc.Adapters;
using Programatica.Framework.Mvc.Authentication;
using Programatica.Framework.Mvc.Options;
using Programatica.Framework.Mvc.Services;
using Programatica.Framework.Services;
using Programatica.Framework.Services.Handlers;
using Programatica.Framework.Services.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Programatica.VerySimpleLogger.Data.Models;
using Programatica.VerySimpleLogger.Handlers;

namespace Programatica.VerySimpleLogger.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            ConfigureLogging(services);
            ConfigureAutoMapper(services);
            ConfigureAuthentication(services);
            ConfigureSession(services);
            ConfigureDatabase(services);
            ConfigureMvc(services);
            ConfigureHttpContext(services);

            ConfigureRepositories(services);
            ConfigureAdapters(services);
            ConfigureEventHandlers(services);
            ConfigureBusiness(services);
            ConfigureServices(services);

        }

        private static void ConfigureDatabase(IServiceCollection services)
        {
            // sqlserver context
            //services.AddDbContext<IDbContext, AppDbContext>(opt => opt.UseSqlServer(Startup.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            // inmemory context
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Startup.Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<IDbContext, AppDbContext>(opt => opt.UseInMemoryDatabase("VerySimpleLogger"), ServiceLifetime.Transient);

            // mysql context
            //services.AddDbContext<IDbContext, AppDbContext>(opt =>
            //       opt.UseMySql(Startup.Configuration.GetConnectionString("DefaultConnection"))
            //   );

        }

        private static void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logoff";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });

            // options
            services.Configure<ClaimBasedAuthAdapterOptions>(Startup
                                                                .Configuration
                                                                .GetSection("ClaimBasedAuthAdapterOptions")
                                                             );
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }

        private static void ConfigureSession(IServiceCollection services)
        {
            services.AddSession(options => options
                                            .IdleTimeout = TimeSpan.FromMinutes(20)
                                );
        }

        private static void ConfigureMvc(IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => options
                                                .SerializerSettings
                                                .ContractResolver = new DefaultContractResolver()
                                   );
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        private static void ConfigureAdapters(IServiceCollection services)
        {
            services.AddScoped<IDateTimeAdapter, DateTimeAdapter>();
            services.AddScoped<IAuthUserAdapter, ClaimBasedAuthAdapter>();
            services.AddScoped<IJsonSerializerAdapter, JsonSerializerAdapter>();
            services.AddScoped<IAppPageAdapter, PageAdapter>();
        }

        private static void ConfigureEventHandlers(IServiceCollection services)
        {
        }

        private static void ConfigureBusiness(IServiceCollection services)
        {
            // injector
            services.AddScoped(typeof(IInjector<>), typeof(Injector<>));

            // service
            services.AddScoped(typeof(IService<>), typeof(Service<>));
        }

        private static void ConfigureHttpContext(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging(builder => builder.AddConsole()
                                                  .AddDebug()
                                                  .AddConfiguration(Startup.Configuration.GetSection("Logging"))
                               );
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMvcControllerDiscoveryService, MvcControllerDiscoveryService>();
        }

    }
}
