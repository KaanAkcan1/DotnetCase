using DotnetCase.Business.Interfaces;
using DotnetCase.Business.Services;
using DotnetCase.Business.Strategies;
using DotnetCase.Data.Contexts;
using DotnetCase.Data.Models;
using DotnetCase.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Net;

namespace DotnetCase.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IAppUserService, AppUserService>()
                .AddTransient<IActivityService, ActivityService>()
                .AddScoped<UserLoginActivityStrategy>()
                .AddScoped<PageViewActivityStrategy>()
                .AddScoped<ExecuteOperationActivityStrategy>()
                .AddScoped<UserLogoutActivityStrategy>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
