using Demo.Services.Common.Enumerations;
using Xomega.Framework;
using Xomega.Framework.Properties;

namespace Demo.Client.Common.DataProperties
{
    public class ScheduleTypeProperty : EnumIntProperty
    {
        public ScheduleTypeProperty(DataObject parent, string name) : base(parent, name)
        {
            EnumType = BusinessObjects.EnumName + BusinessObjects.MaintenanceTemplate;
        }
    }
}
