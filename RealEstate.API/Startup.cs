using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RealEstate.API.Controllers;
using RealEstate.Core;
using RealEstate.Core.Extensions;
using RealEstate.Core.ExternalServices;
using RealEstate.Core.ExternalServices.ATTOM;
using RealEstate.Core.ExternalServices.Zillow;

namespace RealEstate.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger _logService;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _env = environment;

            _logService = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Startup>();
        }

        public AppSettings AppSettings => _configuration.Get<AppSettings>();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<REErrorHandler>();
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddScoped<IExternalApiFactory, ExternalApiFactory>();
            services.AddScoped<IApiFactory, ApiFactory>();

            services.AddApiService<ATTOMApiConfig, Api, ATTOMApi>(AppSettings.ATTOMConfig);
            services.AddApiService<ZillowApiConfig, Api, ZillowApi>(AppSettings.ZillowConfig);

            services.AddScoped<ATTOMApiHandler>().AddScoped<IApi, ATTOMApiHandler>(s => s.GetService<ATTOMApiHandler>());
            services.AddScoped<ZillowApiHandler>().AddScoped<IApi, ZillowApiHandler>(s => s.GetService<ZillowApiHandler>());

            services.AddScoped<ATTOMApi>().AddScoped<Api, ATTOMApi>(s => s.GetService<ATTOMApi>());
            services.AddScoped<ZillowApi>().AddScoped<Api, ZillowApi>(s => s.GetService<ZillowApi>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "RealEstate", 
                    Version = "v1",
                    Description = "This API connects to a plethora of real estate API's such as ATTOM, Zillow, etc and will gather information users or services may need."
                });

                var dir = new DirectoryInfo(AppContext.BaseDirectory);
                foreach (var file in dir.GetFiles("*.xml"))
                {
                    c.IncludeXmlComments(file.FullName);
                }

                c.SchemaFilter<SwaggerFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstate v1");
            });
        }
    }
}
