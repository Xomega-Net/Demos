//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Blazor Views" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Demo.Client.Common.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Blazor.Views;
using Xomega.Framework.Views;

namespace Demo.Client.Blazor.Common.Views
{
    public partial class BusinessObjectTypeListViewBase : BlazorSearchView
    {
        [Inject] protected BusinessObjectTypeListViewModel VM { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            BindTo(VM);
        }

        public override void BindTo(ViewModel viewModel)
        {
            VM = viewModel as BusinessObjectTypeListViewModel;
            base.BindTo(viewModel);
        }

        protected BusinessObjectTypeView cvBusinessObjectTypeView;

        protected override BlazorView[] ChildViews => new BlazorView[]
        {
            cvBusinessObjectTypeView,
        };
    
        protected virtual async Task LinkDetails_ClickAsync(DataRow row, CancellationToken token = default)
        {
            if (VM != null && VM.LinkDetails_Enabled(row))
                await VM.LinkDetails_CommandAsync(cvBusinessObjectTypeView, cvBusinessObjectTypeView.Visible ? cvBusinessObjectTypeView : null, row, token);
        }
    
        protected virtual async Task LinkNew_ClickAsync(CancellationToken token = default)
        {
            if (VM != null && VM.LinkNew_Enabled())
                await VM.LinkNew_CommandAsync(cvBusinessObjectTypeView, cvBusinessObjectTypeView.Visible ? cvBusinessObjectTypeView : null, token);
        }
    }
}
