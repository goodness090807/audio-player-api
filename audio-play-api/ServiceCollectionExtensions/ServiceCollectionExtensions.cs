using BussinessLayer.ExternalServices.Cloudinary;
using CloudinaryDotNet;
using DataAccessLayer.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace audio_play_api.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCloudinarySerivce(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptions<AppSettings>>().Value;

                var account = new Account(options.CloudinarySettings.CloudName,
                    options.CloudinarySettings.APIKey,
                    options.CloudinarySettings.APISecret);

                return new Cloudinary(account);
            });

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbSessingOptions>(configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            return services;
        }
    }
}
