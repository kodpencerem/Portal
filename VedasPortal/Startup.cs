using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System.Net.Http;
using VedasPortal.Areas.Identity;
using VedasPortal.Data;
using VedasPortal.Models.OpenWeatherMapApi;
using VedasPortal.Repository.Interface;

namespace VedasPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VedasDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<VedasDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSyncfusionBlazor();
            services.AddSingleton<IHavaTahmin, OpenWeatherMapApiService>();
            services.AddScoped<HttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTMzMjY1QDMxMzkyZTMzMmUzMEdvdkJCc3FpRHpFMzlTRTJ0VnBRWUdxSXdwUTBXRUFuM3NPUG5ROW9OeW89;" +
                "NTMzMjY2QDMxMzkyZTMzMmUzMGNiaTJrSmNVTjNUYkVRVldFL1RPWlpFME1EZWlWVUFhRzZRTVBKRUhDcGc9;" +
                "NTMzMjY3QDMxMzkyZTMzMmUzMEVVNjFWbytRY24zcWI0cXdOYXBJUWoyQTNydWFRa3VXK3dOQklVbTRMSXM9;" +
                "NTMzMjY4QDMxMzkyZTMzMmUzMGw5c1lMZDNsejFSbmNoZWNqU2ZzbG10RUV0bGRTQTFHdUhsZTl1bnBvVHM9;" +
                "NTMzMjY5QDMxMzkyZTMzMmUzMEE1dytjK1dCNWVWNjZXWENadG5IWloyd3BQTkJNT2xDa3Y3V1RFZ0JRVU09;" +
                "NTMzMjcwQDMxMzkyZTMzMmUzMFFXV0V4eTBVZHVSdE5KUlEzSVRuKy9vYVdRVEVaVGIzaWpja0pWcDJsbW89;" +
                "NTMzMjcxQDMxMzkyZTMzMmUzMGNTT2pWY2dPQmxIcnREcjBhMndiRzNNWjh1K00vTGxESHdpQ2tQL3cydFk9;" +
                "NTMzMjcyQDMxMzkyZTMzMmUzMEhndGNocC9GTUtnODh2SXRnSHJ3VkVNdXZTV0k0d2djYWVaVHdwNmpGdWs9;" +
                "NTMzMjczQDMxMzkyZTMzMmUzMGRMY2RuODB6aTlRdnBBSm9wdlZUdHZFckNNaERPTkZEU0tSeHRtYUs2cEE9;" +
                "NTMzMjc0QDMxMzkyZTMzMmUzMGZpUlAxbkVxSGl1eUdhQ0d4OTd2Wkt2NGhFRERjYlcrMHhtT3J5Q3ZCZWs9;" +
                "NTMzMjc1QDMxMzkyZTMzMmUzMFpTY1NqMlpLcm41Mnh3VjhnTjcyU1lUaTU5RjZiTW4yRmNJY25oZTA4OE09");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
