using audio_play_api.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace audio_play_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option => option.AddPolicy("AllowEveryThing",
               builder => builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader()));

            services.Configure<AppSettings>(Configuration);

            services.AddCloudinarySerivce()
                .AddUnitOfWork(Configuration.GetSection("ConnectionString").Value)
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

            app.UseCors("AllowEveryThing");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
