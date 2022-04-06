using Demo.Services.Common.Enumerations;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Lookup;
using Xomega.Framework.Properties;

namespace Demo.Client.Common.DataObjects
{
    public class BusinessObjectTypeObjectCustomized : BusinessObjectTypeObject
    {
        public BusinessObjectTypeObjectCustomized()
        {
        }

        public BusinessObjectTypeObjectCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private void RefreshCache()
        {
            var cacheProvider = ServiceProvider.GetService(typeof(ILookupCacheProvider)) as ILookupCacheProvider;
            if (cacheProvider == null) throw new Exception("Cannot get ILookupCacheProvider");
            var globalCache = cacheProvider.GetLookupCache(LookupCache.Global);
            
            var boEnum = BusinessObjects.EnumName;
            var boTable = globalCache.GetLookupTable(boEnum);
            foreach (var bo in boTable.GetValues())
            {
                globalCache.RemoveLookupTable(boEnum + bo.Id);
            }
        }

        protected async override Task<ErrorList> DoSaveAsync(object options, CancellationToken token = default)
        {
            var res = await base.DoSaveAsync(options, token);
            if (!res.HasErrors())
                RefreshCache();
            return res;
        }

        protected async override Task<ErrorList> DoDeleteAsync(object options, CancellationToken token = default)
        {
            var res = await base.DoDeleteAsync(options, token);
            if (!res.HasErrors())
                RefreshCache();
            return res;
        }
    }
}