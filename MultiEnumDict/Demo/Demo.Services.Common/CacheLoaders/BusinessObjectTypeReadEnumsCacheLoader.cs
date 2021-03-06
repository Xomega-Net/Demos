//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Lookup Cache Loaders" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Lookup;
using Xomega.Framework.Services;

namespace Demo.Services.Common
{
    public partial class BusinessObjectTypeReadEnumsCacheLoader : LookupCacheLoader 
    {
        public BusinessObjectTypeReadEnumsCacheLoader(IServiceProvider serviceProvider)
            : base(serviceProvider, LookupCache.Global, true)
        {
        }

        protected virtual async Task<Output<ICollection<BusinessObjectType_ReadEnumsOutput>>> ReadEnumsAsync(CancellationToken token = default)
        {
            using (var s = serviceProvider.CreateScope())
            {
                var svc = s.ServiceProvider.GetService<IBusinessObjectTypeService>();
                return await svc.ReadEnumsAsync();
            }
        }

        protected override async Task LoadCacheAsync(string tableType, CacheUpdater updateCache, CancellationToken token = default)
        {
            Dictionary<string, Dictionary<string, Header>> data = new Dictionary<string, Dictionary<string, Header>>();
            var output = await ReadEnumsAsync(token);
            if (output?.Messages != null)
                output.Messages.AbortIfHasErrors();
            else if (output?.Result == null) return;

            foreach (var row in output.Result)
            {
                string type = row.EnumType;

                if (!data.TryGetValue(type, out Dictionary<string, Header> tbl))
                {
                    data[type] = tbl = new Dictionary<string, Header>();
                }
                string id = "" + row.Id;
                if (!tbl.TryGetValue(id, out Header h))
                {
                    tbl[id] = h = new Header(type, id, row.Stub);
                    h.IsActive = IsActive(row.Active);
                }
                h.AddToAttribute("description", row.Description);
            }
            // if no data is returned we still need to update cache to mark it as loaded
            if (data.Count == 0) updateCache(new LookupTable(tableType, new List<Header>(), true));
            foreach (string type in data.Keys)
                updateCache(new LookupTable(type, data[type].Values, true));
        }
    }
}