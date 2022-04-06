using Demo.Services.Common.Enumerations;
using Xomega.Framework;
using Xomega.Framework.Properties;

namespace Demo.Client.Common.DataProperties
{
    public class WorkOrderTypeProperty : EnumIntProperty
    {
        public WorkOrderTypeProperty(DataObject parent, string name) : base(parent, name)
        {
            EnumType = BusinessObjects.EnumName + BusinessObjects.WorkOrder;
        }
    }
}
