//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Xomega Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Demo.Client.Common.DataProperties;
using Demo.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Lookup;
using Xomega.Framework.Properties;
using Xomega.Framework.Services;

namespace Demo.Client.Common.DataObjects
{
    public partial class MaintenanceTemplateList : DataListObject
    {
        #region Constants

        public const string Active = "Active";
        public const string Description = "Description";
        public const string Duration = "Duration";
        public const string Id = "Id";
        public const string ScheduleType = "ScheduleType";
        public const string Stub = "Stub";
        public const string WorkOrderType = "WorkOrderType";

        #endregion

        #region Properties

        public EnumBoolProperty ActiveProperty { get; private set; }
        public TextProperty DescriptionProperty { get; private set; }
        public IntegerProperty DurationProperty { get; private set; }
        public IntegerKeyProperty IdProperty { get; private set; }
        public ScheduleTypeProperty ScheduleTypeProperty { get; private set; }
        public TextProperty StubProperty { get; private set; }
        public WorkOrderTypeProperty WorkOrderTypeProperty { get; private set; }

        #endregion

        #region Actions

        public ActionProperty DetailsAction { get; private set; }
        public ActionProperty NewAction { get; private set; }

        #endregion

        #region Construction

        public MaintenanceTemplateList()
        {
        }

        public MaintenanceTemplateList(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            IdProperty = new IntegerKeyProperty(this, Id)
            {
                Required = true,
                Editable = false,
                IsKey = true,
            };
            StubProperty = new TextProperty(this, Stub)
            {
                Size = 30,
                Editable = false,
            };
            DescriptionProperty = new TextProperty(this, Description)
            {
                Size = 255,
                Editable = false,
            };
            ScheduleTypeProperty = new ScheduleTypeProperty(this, ScheduleType)
            {
                Required = true,
                Editable = false,
            };
            WorkOrderTypeProperty = new WorkOrderTypeProperty(this, WorkOrderType)
            {
                Required = true,
                Editable = false,
            };
            DurationProperty = new IntegerProperty(this, Duration)
            {
                Editable = false,
            };
            ActiveProperty = new EnumBoolProperty(this, Active)
            {
                EnumType = "yesno",
                LookupValidation = LookupValidationType.None,
                Editable = false,
            };
          DetailsAction = new ActionProperty(this, "Details");
          NewAction = new ActionProperty(this, "New");
        }

        #endregion

        #region CRUD Operations

        protected override async Task<ErrorList> DoReadAsync(object options, CancellationToken token = default)
        {
            var output = await MaintenanceTemplate_ReadListAsync(options, 
                CriteriaObject?.ToDataContract<MaintenanceTemplate_ReadListInput_Criteria>(options), token);
            return output.Messages;
        }

        #endregion

        #region Service Operations

        protected virtual async Task<Output<ICollection<MaintenanceTemplate_ReadListOutput>>> MaintenanceTemplate_ReadListAsync(object options, MaintenanceTemplate_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<IMaintenanceTemplateService>().ReadListAsync(_criteria, token);

                await FromDataContractAsync(output?.Result, options, token);
                return output;
            }
        }

        #endregion
    }
}