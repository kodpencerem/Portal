#region Usings
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using VedasPortal.Areas.Identity;
using VedasPortal.Data;
using VedasPortal.Entities.Models;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Entities.Models.IKUygulama;
using VedasPortal.Entities.Models.Kanban;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Entities.Models.User;
using VedasPortal.Entities.Models.Video;
using VedasPortal.Entities.Models.Yorum;
using VedasPortal.Repository;
using VedasPortal.Repository.Interface;
using VedasPortal.Repository.Interface.Anket;
using VedasPortal.Services.Anket;
using VedasPortal.Services.Doviz;
using VedasPortal.Services.FileUploadDownload;
using VedasPortal.Services.HavaDurumuService;
using VedasPortal.Services.ToplantiServices;
using VedasPortal.Utils.Anket.FromMapper;

#endregion

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
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
            services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VedasDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddBlazoredModal();
            services.AddBlazoredToast();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<HttpClient>();
            services.AddScoped<HavaDurumuService>();
            services.AddScoped<Mapper>();
            services.AddScoped<AltinDegisimleriServisi>();
            services.AddScoped<AylikToplantiService>();
            services.AddScoped<ToplantiService>();
            services.AddScoped<IBaseRepository<HaberDuyuru>, BaseRepository<HaberDuyuru> >();
            services.AddScoped<IBaseRepository<Dosya>, BaseRepository<Dosya>>();
            services.AddScoped<IBaseRepository<Etkinlik>, BaseRepository<Etkinlik>>();
            services.AddScoped<IBaseRepository<Katilimci>, BaseRepository<Katilimci>>();
            services.AddScoped<IBaseRepository<DuzelticiFaaliyet>, BaseRepository<DuzelticiFaaliyet>>();
            services.AddScoped<IBaseRepository<Egitim>, BaseRepository<Egitim>>();
            services.AddScoped<IBaseRepository<Mevzuat>, BaseRepository<Mevzuat>>();
            services.AddScoped<IBaseRepository<Video>, BaseRepository<Video>>();
            services.AddScoped<IBaseRepository<Oneri>, BaseRepository<Oneri>>();
            services.AddScoped<IBaseRepository<ToplantiNotu>, BaseRepository<ToplantiNotu>>();
            services.AddScoped<IBaseRepository<KursVeSertifika>, BaseRepository<KursVeSertifika>>();
            services.AddScoped<IBaseRepository<OkulMezunBilgisi>, BaseRepository<OkulMezunBilgisi>>();
            services.AddScoped<IBaseRepository<Yorum>, BaseRepository<Yorum>>();
            services.AddScoped<IBaseRepository<ToplantiOdasi>, BaseRepository<ToplantiOdasi>>();
            services.AddScoped<IBaseRepository<IkUygulama>, BaseRepository<IkUygulama>>();
            services.AddScoped<IBaseRepository<GorevSecenek>, BaseRepository<GorevSecenek>>();
            services.AddScoped<IBaseRepository<Rehber>, BaseRepository<Rehber>>();
            services.AddScoped<IFileUpload, FileUpload>();           
            services.AddScoped<IFileDownload, FileDownload>();
            services.AddScoped<IModalService, ModalService>();           
            services.AddTransient<IToplantiTakvimi, ToplantiTakvimi>();           
            services.AddScoped<IAnketYonetim, AnketYonetim>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();          
            services.AddScoped<IBaseRepository<Toplanti>, BaseRepository<Toplanti>>();
            services.AddTransient<IEmailSender, EmailSender>();

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
