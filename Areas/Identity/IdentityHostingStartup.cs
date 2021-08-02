using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMasterIdentity.Areas.Identity.Data;
using WebMasterIdentity.Data;

[assembly: HostingStartup(typeof(WebMasterIdentity.Areas.Identity.IdentityHostingStartup))]
namespace WebMasterIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebMasterIdentityDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebMasterConnection")));

                services.AddDefaultIdentity<WebMasterIdentityUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                    .AddEntityFrameworkStores<WebMasterIdentityDBContext>();
            });
        }
    }
}