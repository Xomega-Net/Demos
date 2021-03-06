//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "View Models" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Demo.Client.Common.DataObjects;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace Demo.Client.Common.ViewModels
{
    public partial class MaintenanceTemplateListViewModel : SearchViewModel
    {
        public MaintenanceTemplateList ListObj => List as MaintenanceTemplateList;
        public MaintenanceTemplateCriteria CritObj => List.CriteriaObject as MaintenanceTemplateCriteria;

        public MaintenanceTemplateListViewModel(IServiceProvider sp) : base(sp)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            List = ServiceProvider.GetService<MaintenanceTemplateList>();
            List.CriteriaObject = ServiceProvider.GetService<MaintenanceTemplateCriteria>();
        }

        #region Link LinkDetails

        public virtual NameValueCollection LinkDetails_Params(DataRow row)
        {
            NameValueCollection query = new NameValueCollection()
            {
                { "Id", ListObj.IdProperty.GetStringValue(ValueFormat.EditString, row) },
                { ViewParams.Mode.Param, ViewParams.Mode.Popup },
                { ViewParams.QuerySource, "LinkDetails" },
            };
            return query;
        }

        public virtual void LinkDetails_Command(IView tgtView, IView curView, DataRow row)
        {
            NameValueCollection query = LinkDetails_Params(row);
            ViewModel tgtModel = ServiceProvider.GetService<MaintenanceTemplateViewModel>();
            NavigateTo(tgtModel, tgtView, query, this, curView);
        }

        public virtual async Task LinkDetails_CommandAsync(IAsyncView tgtView, IAsyncView curView, DataRow row, CancellationToken token = default)
        {
            NameValueCollection query = LinkDetails_Params(row);
            ViewModel tgtModel = ServiceProvider.GetService<MaintenanceTemplateViewModel>();
            await NavigateToAsync(tgtModel, tgtView, query, this, curView, token);
        }

        public virtual bool LinkDetails_Enabled(DataRow row)
        {
            return true;
        }
        #endregion

        #region Link LinkNew

        public virtual NameValueCollection LinkNew_Params()
        {
            NameValueCollection query = new NameValueCollection()
            {
                { ViewParams.Action.Param, ViewParams.Action.Create },
                { ViewParams.Mode.Param, ViewParams.Mode.Popup },
                { ViewParams.QuerySource, "LinkNew" },
            };
            return query;
        }

        public virtual void LinkNew_Command(IView tgtView, IView curView)
        {
            NameValueCollection query = LinkNew_Params();
            ViewModel tgtModel = ServiceProvider.GetService<MaintenanceTemplateViewModel>();
            NavigateTo(tgtModel, tgtView, query, this, curView);
        }

        public virtual async Task LinkNew_CommandAsync(IAsyncView tgtView, IAsyncView curView, CancellationToken token = default)
        {
            NameValueCollection query = LinkNew_Params();
            ViewModel tgtModel = ServiceProvider.GetService<MaintenanceTemplateViewModel>();
            await NavigateToAsync(tgtModel, tgtView, query, this, curView, token);
        }

        public virtual bool LinkNew_Enabled()
        {
            return true;
        }
        #endregion
    }
}