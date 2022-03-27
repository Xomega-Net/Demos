//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Implementations" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated
// unless they are placed between corresponding CUSTOM_CODE_START/CUSTOM_CODE_END lines.
//
// This file can be DELETED DURING REGENERATION IF NO LONGER NEEDED, e.g. if it gets renamed.
// To prevent this and preserve manual custom changes please remove the line above.
//---------------------------------------------------------------------------------------------

using Demo.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;
// CUSTOM_CODE_START: add namespaces for custom code below
// CUSTOM_CODE_END

namespace Demo.Services.Entities
{
    public partial class MaintenanceTemplateService : BaseService, IMaintenanceTemplateService
    {
        protected DemoEntities ctx;

        public MaintenanceTemplateService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            ctx = serviceProvider.GetService<DemoEntities>();
        }

        public virtual async Task<Output<MaintenanceTemplate_ReadOutput>> ReadAsync(int _id, CancellationToken token = default)
        {
            MaintenanceTemplate_ReadOutput res = new MaintenanceTemplate_ReadOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Read operation below
                // CUSTOM_CODE_END
                MaintenanceTemplate obj = await ctx.FindEntityAsync<MaintenanceTemplate>(currentErrors, token, _id);
                ServiceUtil.CopyProperties(obj, res);
                // CUSTOM_CODE_START: add custom code for Read operation below
                // CUSTOM_CODE_END
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<MaintenanceTemplate_ReadOutput>(currentErrors, res));
        }

        public virtual async Task<Output<MaintenanceTemplate_CreateOutput>> CreateAsync(MaintenanceTemplate_CreateInput _data, CancellationToken token = default)
        {
            MaintenanceTemplate_CreateOutput res = new MaintenanceTemplate_CreateOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Create operation below
                // CUSTOM_CODE_END
                EntityState state = EntityState.Added;
                MaintenanceTemplate obj = new MaintenanceTemplate();
                var entry = ctx.Entry(obj);
                entry.State = state;
                entry.CurrentValues.SetValues(_data);
                await ctx.ValidateKeyAsync<BusinessObjectType>(currentErrors, token, "ScheduleType", _data.ScheduleType);
                await ctx.ValidateKeyAsync<BusinessObjectType>(currentErrors, token, "WorkOrderType", _data.WorkOrderType);
                // CUSTOM_CODE_START: add custom code for Create operation below
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
                ServiceUtil.CopyProperties(obj, res);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<MaintenanceTemplate_CreateOutput>(currentErrors, res));
        }

        public virtual async Task<Output> UpdateAsync(int _id, MaintenanceTemplate_UpdateInput_Data _data, CancellationToken token = default)
        {
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Update operation below
                // CUSTOM_CODE_END
                MaintenanceTemplate obj = await ctx.FindEntityAsync<MaintenanceTemplate>(currentErrors, token, _id);
                var entry = ctx.Entry(obj);
                entry.CurrentValues.SetValues(_data);
                await ctx.ValidateKeyAsync<BusinessObjectType>(currentErrors, token, "ScheduleType", _data.ScheduleType);
                await ctx.ValidateKeyAsync<BusinessObjectType>(currentErrors, token, "WorkOrderType", _data.WorkOrderType);
                // CUSTOM_CODE_START: add custom code for Update operation below
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output(currentErrors));
        }

        public virtual async Task<Output> DeleteAsync(int _id, CancellationToken token = default)
        {
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Delete operation below
                // CUSTOM_CODE_END
                EntityState state = EntityState.Deleted;
                MaintenanceTemplate obj = await ctx.FindEntityAsync<MaintenanceTemplate>(currentErrors, token, _id);
                var entry = ctx.Entry(obj);
                entry.State = state;
                // CUSTOM_CODE_START: add custom code for Delete operation below
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output(currentErrors));
        }

        public virtual async Task<Output<ICollection<MaintenanceTemplate_ReadListOutput>>> ReadListAsync(MaintenanceTemplate_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            ICollection<MaintenanceTemplate_ReadListOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for ReadList operation below
                // CUSTOM_CODE_END
                var src = from obj in ctx.MaintenanceTemplate select obj;

                // CUSTOM_CODE_START: add custom filter criteria to the source query for ReadList operation below
                // src = src.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new MaintenanceTemplate_ReadListOutput() {
                              Id = obj.Id,
                              Stub = obj.Stub,
                              Description = obj.Description,
                              ScheduleType = obj.ScheduleType,
                              WorkOrderType = obj.WorkOrderType,
                              Duration = obj.Duration,
                              Active = obj.Active,
                          };

                // Result filter
                if (_criteria != null)
                {
                    qry = AddClause(qry, "Stub", o => o.Stub, _criteria.StubOperator, _criteria.Stub);
                    qry = AddClause(qry, "Description", o => o.Description, _criteria.DescriptionOperator, _criteria.Description);
                    qry = AddClause(qry, "ScheduleType", o => o.ScheduleType, _criteria.ScheduleTypeOperator, _criteria.ScheduleType);
                    qry = AddClause(qry, "WorkOrderType", o => o.WorkOrderType, _criteria.WorkOrderTypeOperator, _criteria.WorkOrderType);
                    qry = AddClause(qry, "Duration", o => o.Duration, _criteria.DurationOperator, _criteria.Duration, _criteria.Duration2);
                    qry = AddClause(qry, "Active", o => o.Active, _criteria.ActiveOperator, _criteria.Active);
                }

                // CUSTOM_CODE_START: add custom filter criteria to the result query for ReadList operation below
                // qry = qry.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                currentErrors.AbortIfHasErrors();
                res = await qry.ToListAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<ICollection<MaintenanceTemplate_ReadListOutput>>(currentErrors, res));
        }
    }
}