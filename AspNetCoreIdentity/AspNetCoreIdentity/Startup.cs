using AspNetCoreIdentity.Config;
using AspNetCoreIdentity.Extensions;
using KissLog;
using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(hostingEnvironment.ContentRootPath)
                                .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile(path: $"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                                .AddEnvironmentVariables();

            if(hostingEnvironment.IsProduction())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfig(Configuration);
            services.AddAuthorizantionConfig();
            services.ResolveDependencies();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AuditoriaFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseKissLogMiddleware();            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            LogConfig.RegisterKissLogListeners(Configuration);
        }
    }
}
