using Demo.Client.Blazor.Common;
using Demo.Client.Blazor.Common.Views;
using Demo.Client.Common.DataObjects;
using Demo.Client.Common.ViewModels;
using Demo.Services.Common;
using Demo.Services.Common.Enumerations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Resources;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Blazor;
using Xomega.Framework.Blazor.Components;

namespace Demo.Client.Blazor.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            App.AdditionalAssemblies = new[] { typeof(Program).Assembly };
            string apiBaseAddress = builder.Configuration.GetValue<string>("RestAPI:BaseAddress");

            var services = builder.Services;

            // Xomega Framework configuration
            services.AddErrors(builder.HostEnvironment.IsEnvironment("Development"));
            services.AddSingletonLookupCacheProvider();
            services.AddXmlResourceCacheLoader(typeof(Operators).Assembly, ".enumerations.xres", true);
            services.AddOperators();
            services.AddSingleton<IPrincipalProvider, AuthStatePrincipalProvider>();

            // App services configuration
            services.AddSingleton<AuthenticationStateProvider, AuthStateProvider>();
            services.AddRestServices(apiBaseAddress);
            services.AddRestClients();
            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Demo.Client.Common.Messages.ResourceManager,
                Demo.Client.Common.Labels.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));
            services.AddDataObjects();
            services.AddViewModels();
            services.AddLookupCacheLoaders();

            // add authorization
            services.AddAuthorizationCore(); // TODO: add security policies

            MainMenu.Items.Insert(0, new MenuItem()
            {
                ResourceKey = Demo.Client.Common.Messages.HomeView_NavMenu,
                IconClass = "bi bi-house-door",
                Href = "/"
            });
            MainMenu.Items[1].Text = "Maintenance";

            foreach (var mi in MainMenu.Items)
                mi.ForEachItem(SecureMenu);

            var host = builder.Build();

            // TODO: add any custom initialization here
            await RestServices.Authenticate(host.Services, "anonymous", null);

            await host.RunAsync();
        }

        private static void SecureMenu(MenuItem mi)
        {
            // TODO: set security policy for navigation menu items here
            mi.Policy = null;
        }
    }
}