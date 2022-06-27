#region Usings
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using BlazorTable;
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
using System;
using System.Net.Http;
using System.Threading.Tasks;
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
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Entities.Models.User;
using VedasPortal.Entities.Models.Yorum;
using VedasPortal.Repository;
using VedasPortal.Repository.Interface;
using VedasPortal.Repository.Interface.Anket;
using VedasPortal.Services.Anket;
using VedasPortal.Services.AuthServices;
using VedasPortal.Services.FileUploadDownload;
using VedasPortal.Services.HavaDurumuService;
using VedasPortal.Services.ToplantiServices;
using VedasPortal.Utils.Anket.FromMapper;
using Syncfusion.Blazor;
using Newtonsoft.Json.Serialization;
using VedasPortal.Entities.Models.Anket;


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
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VedasDbContext>();
            services.AddRazorPages().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddServerSideBlazor();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddBlazoredModal();
            services.AddBlazoredToast();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
            services.AddScoped<HttpClient>();
            services.AddScoped<HavaDurumuService>();
            services.AddScoped<Mapper>();
            services.AddScoped<AylikToplantiService>();
            services.AddScoped<ToplantiService>();
            services.AddBlazorTable();
            services.AddScoped<IBaseRepository<HaberDuyuru>, BaseRepository<HaberDuyuru>>();
            services.AddScoped<IBaseRepository<ImageFile>, BaseRepository<ImageFile>>();
            services.AddScoped<IBaseRepository<Etkinlik>, BaseRepository<Etkinlik>>();
            services.AddScoped<IBaseRepository<Katilimci>, BaseRepository<Katilimci>>();
            services.AddScoped<IBaseRepository<DuzelticiFaaliyet>, BaseRepository<DuzelticiFaaliyet>>();
            services.AddScoped<IBaseRepository<Egitim>, BaseRepository<Egitim>>();
            services.AddScoped<IBaseRepository<Mevzuat>, BaseRepository<Mevzuat>>();
            services.AddScoped<IBaseRepository<Oneri>, BaseRepository<Oneri>>();
            services.AddScoped<IBaseRepository<ToplantiNotu>, BaseRepository<ToplantiNotu>>();
            services.AddScoped<IBaseRepository<KursVeSertifika>, BaseRepository<KursVeSertifika>>();
            services.AddScoped<IBaseRepository<OkulMezunBilgisi>, BaseRepository<OkulMezunBilgisi>>();
            services.AddScoped<IBaseRepository<Yorum>, BaseRepository<Yorum>>();
            services.AddScoped<IBaseRepository<ToplantiOdasi>, BaseRepository<ToplantiOdasi>>();
            services.AddScoped<IBaseRepository<IkUygulama>, BaseRepository<IkUygulama>>();
            services.AddScoped<IBaseRepository<GorevSecenek>, BaseRepository<GorevSecenek>>();
            services.AddScoped<IBaseRepository<UzmanlikAlani>, BaseRepository<UzmanlikAlani>>();
            services.AddScoped<IBaseRepository<Rehber>, BaseRepository<Rehber>>();
            services.AddScoped<IBaseRepository<Dosya>, BaseRepository<Dosya>>();
            services.AddScoped<IBaseRepository<PersonelDurum>, BaseRepository<PersonelDurum>>();
            services.AddScoped<IBaseRepository<ToplantiMerkezi>, BaseRepository<ToplantiMerkezi>>();
            services.AddScoped<IBaseRepository<VefatDurumu>, BaseRepository<VefatDurumu>>();
            services.AddScoped<IBaseRepository<AnketUser>, BaseRepository<AnketUser>>();
            services.AddScoped<IFileUpload, FileUpload>();
            services.AddScoped<IFileDownload, FileDownload>();
            services.AddScoped<IModalService, ModalService>();
            services.AddTransient<IToplantiTakvimi, ToplantiTakvimi>();
            services.AddScoped<IAnketYonetim, AnketYonetim>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IBaseRepository<Toplanti>, BaseRepository<Toplanti>>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSyncfusionBlazor();
            services.AddTransient<IManageUsersService, ManageUsersService>();
            services.AddTransient<IManageRolesService, ManageRolesService>();
            services.AddBlazorise().AddBootstrapProviders().AddFontAwesomeIcons();
            services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjU5MzAyQDMyMzAyZTMxMmUzME9RQ1ZFeGdRNW9MaGpNdWcxNXh4YjQrMDh5VzF4bzExN0V4Q2lmSjNsMTA9");
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
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var _RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Client" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await _RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await _RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var user = await _UserManager.FindByEmailAsync("emrullah04@outlook.com");

            if (user != null)
            {
                var roles = await _UserManager.GetRolesAsync(user);
                if (roles == null || !roles.Contains("Admin"))
                {
                    await _UserManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

    }
}
