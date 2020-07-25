using BlazorStrap;
using CSGOSkinsWeb.Core.Services;
using CSGOSkinsWeb.Database;
using CSGOSkinsWeb.Database.Models;
using CSGOSkinsWeb.Web.Areas.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSGOSkinsWeb.Web
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
            services.AddDbContext<SkinDbContext>(options =>
            {
                // Connection string moved to external file for security reasons. 
                options.UseSqlServer(Configuration.GetConnectionString(@"connString"), x => x.MigrationsAssembly("CSGOSkinsWeb.Database.Migrations"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddDefaultIdentity<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SkinDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBootstrapCss();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AppUser>>();

            services.AddScoped<IWeaponService, WeaponService>();
            services.AddScoped<ICaseService, CaseService>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<ISkinService, SkinService>();
            services.AddScoped<IRarityService, RarityService>();
            services.AddScoped<ICasePriceService, CasePriceService>();
            services.AddScoped<ISkinPriceService, SkinPriceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
