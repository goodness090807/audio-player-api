using audio_player_api.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace audio_player_api
{
    public class Startup
    {
        private readonly string _corsPolicyName = "AllowDevelopAndProductionDomain";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option => option.AddPolicy(_corsPolicyName,
               builder => builder.WithOrigins("http://localhost:3000/")
                                 .AllowAnyMethod()
                                 .AllowAnyHeader()));

            services.Configure<AppSettings>(Configuration);

            services.AddCloudinarySerivce(Configuration.GetSection("CloudinarySettings").Get<AppSettings.CloudinarySettingsDto>())
                .AddUnitOfWork(Configuration["ConnectionString"])
                .AddRepository()
                .AddBusinessService();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_corsPolicyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
