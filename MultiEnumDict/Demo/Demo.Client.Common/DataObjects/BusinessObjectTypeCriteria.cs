//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Xomega Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;
using Xomega.Framework;
using Xomega.Framework.Lookup;
using Xomega.Framework.Properties;

namespace Demo.Client.Common.DataObjects
{
    public partial class BusinessObjectTypeCriteria : CriteriaObject
    {
        #region Constants

        public const string Active = "Active";
        public const string ActiveOperator = "ActiveOperator";
        public const string BusinessObject = "BusinessObject";
        public const string BusinessObject2 = "BusinessObject2";
        public const string BusinessObjectOperator = "BusinessObjectOperator";
        public const string Description = "Description";
        public const string DescriptionOperator = "DescriptionOperator";
        public const string Stub = "Stub";
        public const string StubOperator = "StubOperator";

        #endregion

        #region Properties

        public EnumBoolProperty ActiveProperty { get; private set; }
        public OperatorProperty ActiveOperatorProperty { get; private set; }
        public EnumIntProperty BusinessObjectProperty { get; private set; }
        public EnumIntProperty BusinessObject2Property { get; private set; }
        public OperatorProperty BusinessObjectOperatorProperty { get; private set; }
        public TextProperty DescriptionProperty { get; private set; }
        public OperatorProperty DescriptionOperatorProperty { get; private set; }
        public TextProperty StubProperty { get; private set; }
        public OperatorProperty StubOperatorProperty { get; private set; }

        #endregion

        #region Construction

        public BusinessObjectTypeCriteria()
        {
        }

        public BusinessObjectTypeCriteria(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            BusinessObjectOperatorProperty = new OperatorProperty(this, BusinessObjectOperator)
            {
                Size = 25,
                EnumType = "operators",
            };
            BusinessObjectProperty = new EnumIntProperty(this, BusinessObject)
            {
                EnumType = "business object",
            };
            BusinessObject2Property = new EnumIntProperty(this, BusinessObject2)
            {
                EnumType = "business object",
            };
            StubOperatorProperty = new OperatorProperty(this, StubOperator)
            {
                Size = 25,
                EnumType = "operators",
                HasNullCheck = true,
            };
            StubProperty = new TextProperty(this, Stub)
            {
                Size = 30,
            };
            DescriptionOperatorProperty = new OperatorProperty(this, DescriptionOperator)
            {
                Size = 25,
                EnumType = "operators",
                HasNullCheck = true,
            };
            DescriptionProperty = new TextProperty(this, Description)
            {
                Size = 255,
            };
            ActiveOperatorProperty = new OperatorProperty(this, ActiveOperator)
            {
                Size = 25,
                EnumType = "operators",
                HasNullCheck = true,
            };
            ActiveProperty = new EnumBoolProperty(this, Active)
            {
                EnumType = "yesno",
                LookupValidation = LookupValidationType.None,
            };
        }

        #endregion
    }
}