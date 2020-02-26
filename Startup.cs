using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using netCoreWorkShop.Services.ArticleService;
using netCoreWorkShop.Services.ArticleService.Abstractions;
using netCoreWorkShop.Data;

namespace netCoreWorkshop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ArticlesContext>(options => options.UseSqlite(Configuration.GetConnectionString("Articles")));

            services.AddControllersWithViews();

            services.AddTransient<IArticleService, ArticleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // For logging
            //var startupLogger = loggerFactory.CreateLogger<Startup>();
            //startupLogger.LogTrace("Trace test output!");
            //startupLogger.LogDebug("Debug test output!");
            //startupLogger.LogInformation("Info test output!");
            //startupLogger.LogError("Error test output!");
            //startupLogger.LogCritical("Trace test output!");

            // Environment deloper exception page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Routing 
            app.UseRouting();

            //Static Files Like Css JS etc
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
