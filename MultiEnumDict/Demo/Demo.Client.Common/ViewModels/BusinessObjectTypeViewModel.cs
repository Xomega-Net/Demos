//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "View Models" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Demo.Client.Common.DataObjects;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xomega.Framework.Views;

namespace Demo.Client.Common.ViewModels
{
    public partial class BusinessObjectTypeViewModel : DetailsViewModel
    {
        public BusinessObjectTypeObject MainObj => DetailsObject as BusinessObjectTypeObject;

        public BusinessObjectTypeViewModel(IServiceProvider sp) : base(sp)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            DetailsObject = ServiceProvider.GetService<BusinessObjectTypeObject>();
        }
    }
}