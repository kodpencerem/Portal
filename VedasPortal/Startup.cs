using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using VedasPortal.Areas.Identity;
using VedasPortal.Data;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.DuzelticiFaaliyet;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Models.Mevzuat;
using VedasPortal.Models.Oneri;
using VedasPortal.Models.Video;
using VedasPortal.Repository;
using VedasPortal.Repository.Interface;
using VedasPortal.Services.FileUploadDownload;
using VedasPortal.Services.HavaDurumuService;
using VedasPortal.Services.VideoService;

namespace VedasPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
            services.AddScoped<HavaDurumuService>();
            //services.AddSingleton<IHavaTahmin, HavaTahmini>();
            services.AddScoped<HttpClient>();
            services.AddScoped<IVideoService, StaticVideoService>();
            services.AddScoped<IBaseRepository<HaberDuyuru>, BaseRepository<HaberDuyuru> >();
            services.AddScoped<IBaseRepository<Dosya>, BaseRepository<Dosya>>();
            services.AddScoped<IBaseRepository<Etkinlik>, BaseRepository<Etkinlik>>();
            services.AddScoped<IBaseRepository<Katilimci>, BaseRepository<Katilimci>>();
            services.AddScoped<IBaseRepository<DuzelticiFaaliyet>, BaseRepository<DuzelticiFaaliyet>>();
            services.AddScoped<IBaseRepository<Egitim>, BaseRepository<Egitim>>();
            services.AddScoped<IBaseRepository<Mevzuat>, BaseRepository<Mevzuat>>();
            services.AddScoped<IBaseRepository<Video>, BaseRepository<Video>>();
            services.AddScoped<IBaseRepository<Oneri>, BaseRepository<Oneri>>();
            // register our scoped service to upload
            services.AddScoped<IFileUpload, FileUpload>();
            // register our scoped service to download
            services.AddScoped<IFileDownload, FileDownload>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
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
