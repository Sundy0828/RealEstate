using Microsoft.Extensions.DependencyInjection;
using RealEstate.Core.ExternalServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiService<TConfig, TClientService, TClient>(this IServiceCollection services, TConfig config)
            where TConfig : IApiConfig
            where TClientService : class
            where TClient : class, TClientService
        {
            services.AddSingleton<TConfig>((_) =>
            {
                if (config?.Verify() != true)
                {
                    throw new ApplicationException("The configuration is missing or invalid");
                }

                return config;
            });

            services.AddScoped<TClientService, TClient>(); 
        }
    }
}
