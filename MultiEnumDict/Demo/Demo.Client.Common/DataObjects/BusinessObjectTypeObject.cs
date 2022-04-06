//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Xomega Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Demo.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Lookup;
using Xomega.Framework.Properties;
using Xomega.Framework.Services;

namespace Demo.Client.Common.DataObjects
{
    public partial class BusinessObjectTypeObject : DataObject
    {
        #region Constants

        public const string Active = "Active";
        public const string BusinessObject = "BusinessObject";
        public const string Description = "Description";
        public const string Id = "Id";
        public const string Stub = "Stub";

        #endregion

        #region Properties

        public EnumBoolProperty ActiveProperty { get; private set; }
        public EnumIntProperty BusinessObjectProperty { get; private set; }
        public TextProperty DescriptionProperty { get; private set; }
        public EnumIntProperty IdProperty { get; private set; }
        public TextProperty StubProperty { get; private set; }

        #endregion

        #region Construction

        public BusinessObjectTypeObject()
        {
        }

        public BusinessObjectTypeObject(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            IdProperty = new EnumIntProperty(this, Id)
            {
                Required = true,
                Editable = false,
                IsKey = true,
            };
            BusinessObjectProperty = new EnumIntProperty(this, BusinessObject)
            {
                Required = true,
                EnumType = "business object",
            };
            StubProperty = new TextProperty(this, Stub)
            {
                Size = 30,
            };
            DescriptionProperty = new TextProperty(this, Description)
            {
                Size = 255,
            };
            ActiveProperty = new EnumBoolProperty(this, Active)
            {
                EnumType = "yesno",
                LookupValidation = LookupValidationType.None,
            };
        }

        #endregion

        #region CRUD Operations

        protected override async Task<ErrorList> DoReadAsync(object options, CancellationToken token = default)
        {
            var output = await BusinessObjectType_ReadAsync(options, token);
            return output.Messages;
        }

        protected override async Task<ErrorList> DoSaveAsync(object options, CancellationToken token = default)
        {
            if (IsNew)
            {
                var output = await BusinessObjectType_CreateAsync(options, token);
                return output.Messages;
            }
            else
            {
                var output = await BusinessObjectType_UpdateAsync(options, token);
                return output.Messages;
            }
        }

        protected override async Task<ErrorList> DoDeleteAsync(object options, CancellationToken token = default)
        {
            var output = await BusinessObjectType_DeleteAsync(options, token);
            return output.Messages;
        }

        #endregion

        #region Service Operations

        protected virtual async Task<Output<BusinessObjectType_ReadOutput>> BusinessObjectType_ReadAsync(object options, CancellationToken token = default)
        {
            int _id = (int)IdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<IBusinessObjectTypeService>().ReadAsync(_id, token);

                await FromDataContractAsync(output?.Result, options, token);
                return output;
            }
        }

        protected virtual async Task<Output<BusinessObjectType_CreateOutput>> BusinessObjectType_CreateAsync(object options, CancellationToken token = default)
        {
            BusinessObjectType_CreateInput _data = ToDataContract<BusinessObjectType_CreateInput>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<IBusinessObjectTypeService>().CreateAsync(_data, token);

                await FromDataContractAsync(output?.Result, options, token);
                return output;
            }
        }

        protected virtual async Task<Output> BusinessObjectType_UpdateAsync(object options, CancellationToken token = default)
        {
            int _id = (int)IdProperty.TransportValue;
            BusinessObjectType_UpdateInput_Data _data = ToDataContract<BusinessObjectType_UpdateInput_Data>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<IBusinessObjectTypeService>().UpdateAsync(_id, _data, token);

                return output;
            }
        }

        protected virtual async Task<Output> BusinessObjectType_DeleteAsync(object options, CancellationToken token = default)
        {
            int _id = (int)IdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<IBusinessObjectTypeService>().DeleteAsync(_id, token);

                return output;
            }
        }

        #endregion
    }
}