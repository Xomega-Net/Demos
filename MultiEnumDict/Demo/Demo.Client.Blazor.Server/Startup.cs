using Demo.Client.Blazor.Common;
using Demo.Client.Blazor.Common.Views;
using Demo.Client.Common.DataObjects;
using Demo.Client.Common.ViewModels;
using Demo.Services.Common.Enumerations;
using Demo.Services.Common;
using Demo.Services.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
#if !EF6
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Resources;
using Xomega.Framework;
using Xomega.Framework.Blazor.Components;
using Xomega.Framework.Services;

namespace Demo.Client.Blazor.Server
{
    public class Startup
    {
        public const string ConfigConnectionString = "add:DemoEntities:connectionString";

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
            App.AdditionalAssemblies = new[] { GetType().Assembly };
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ASP.NET configuration
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();

            // Xomega Framework configuration
            services.AddErrors(env.IsDevelopment());
            services.AddSingletonLookupCacheProvider();
            services.AddXmlResourceCacheLoader(typeof(Operators).Assembly, ".enumerations.xres", false);
            services.AddOperators();
            services.AddTransient<IPrincipalProvider, ContextPrincipalProvider>();
            services.AddScoped<SignInManager>();

            // App services configuration
            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Demo.Client.Common.Messages.ResourceManager,
                Demo.Client.Common.Labels.ResourceManager,
                Demo.Services.Entities.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));
            string connStr = configuration.GetValue<string>(ConfigConnectionString);
#if EF6
            services.AddScoped(sp => new DemoEntities(connStr));
#else
            services.AddDbContext<DemoEntities>(opt => opt.UseLazyLoadingProxies().UseSqlServer(connStr));
#endif
            services.AddServiceImplementations();
            services.AddDataObjects();
            services.AddViewModels();
            services.AddLookupCacheLoaders();

            MainMenu.Items.Insert(0, new MenuItem()
            {
                ResourceKey = Demo.Client.Common.Messages.HomeView_NavMenu,
                IconClass = "bi bi-house-door",
                Href = "/"
            });
            MainMenu.Items[1].Text = "Maintenance";

            // TODO: add authorization with any security policies

            foreach (var mi in MainMenu.Items)
                mi.ForEachItem(SecureMenu);
        }

        private void SecureMenu(MenuItem mi)
        {
            // TODO: set security policy for navigation menu items here
            mi.Policy = null;
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

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapRazorPages();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}