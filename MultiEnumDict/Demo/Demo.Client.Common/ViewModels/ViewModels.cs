//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "View Models" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace Demo.Client.Common.ViewModels
{
    public static class ViewModels
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<MaintenanceTemplateViewModel, MaintenanceTemplateViewModel>();
            services.AddTransient<MaintenanceTemplateListViewModel, MaintenanceTemplateListViewModel>();
            return services;
        }
    }
}