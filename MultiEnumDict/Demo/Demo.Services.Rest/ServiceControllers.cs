//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Web API Controllers" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace Demo.Services.Rest
{
    public static class ServiceControllers
    {
        public static IServiceCollection AddServiceControllers(this IServiceCollection services)
        {
            services.AddScoped<BusinessObjectTypeController, BusinessObjectTypeController>();
            services.AddScoped<MaintenanceTemplateController, MaintenanceTemplateController>();
            return services;
        }
    }
}