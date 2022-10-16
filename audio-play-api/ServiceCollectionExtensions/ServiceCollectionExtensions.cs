using BussinessLayer.ExternalServices.Cloudinary;
using BussinessLayer.Services.Audio;
using CloudinaryDotNet;
using DataAccessLayer.Repositories.Audio;
using DataAccessLayer.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace audio_play_api.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCloudinarySerivce(this IServiceCollection services)
        {
            services.AddScoped(sp =>
            {
                var options = sp.GetRequiredService<IOptions<AppSettings>>().Value;

                var account = new Account(options.CloudinarySettings.CloudName,
                    options.CloudinarySettings.APIKey,
                    options.CloudinarySettings.APISecret);

                return new Cloudinary(account);
            });

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbConnection>(sp => 
            {
                return new MySqlConnection(connectionString);
            });

            services.AddScoped<DbSession>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IAudioService, AudioService>();

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IAudioRepository, AudioRepository>();
            return services;
        }
    }
}
