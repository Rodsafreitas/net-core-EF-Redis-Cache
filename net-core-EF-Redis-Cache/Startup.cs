using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using net_core_EF_Redis_Cache.Models;
using net_core_EF_Redis_Cache.Data;
using net_core_EF_Redis_Cache.Business;

namespace net_core_EF_Redis_Cache
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
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Weather")            
                )
            );
            
           services.AddScoped<WeatherService>();
                        
           services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("CacheRedis");
                options.InstanceName = "Cache-Redis";
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Weather}/{action=Index}/{id?}"
                );
            });
        }
    }
}
