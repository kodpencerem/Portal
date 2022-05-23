using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(VedasPortal.Areas.Identity.IdentityHostingStartup))]
namespace VedasPortal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}