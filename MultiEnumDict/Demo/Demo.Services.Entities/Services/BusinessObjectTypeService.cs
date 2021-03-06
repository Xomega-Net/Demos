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
using Demo.Services.Common.Enumerations;
// CUSTOM_CODE_END

namespace Demo.Services.Entities
{
    public partial class BusinessObjectTypeService : BaseService, IBusinessObjectTypeService
    {
        protected DemoEntities ctx;

        public BusinessObjectTypeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            ctx = serviceProvider.GetService<DemoEntities>();
        }

        public virtual async Task<Output<BusinessObjectType_ReadOutput>> ReadAsync(int _id, CancellationToken token = default)
        {
            BusinessObjectType_ReadOutput res = new BusinessObjectType_ReadOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Read operation below
                // CUSTOM_CODE_END
                BusinessObjectType obj = await ctx.FindEntityAsync<BusinessObjectType>(currentErrors, token, _id);
                ServiceUtil.CopyProperties(obj, res);
                // CUSTOM_CODE_START: add custom code for Read operation below
                // CUSTOM_CODE_END
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<BusinessObjectType_ReadOutput>(currentErrors, res));
        }

        public virtual async Task<Output<BusinessObjectType_CreateOutput>> CreateAsync(BusinessObjectType_CreateInput _data, CancellationToken token = default)
        {
            BusinessObjectType_CreateOutput res = new BusinessObjectType_CreateOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Create operation below
                // CUSTOM_CODE_END
                EntityState state = EntityState.Added;
                BusinessObjectType obj = new BusinessObjectType();
                var entry = ctx.Entry(obj);
                entry.State = state;
                entry.CurrentValues.SetValues(_data);
                await ctx.ValidateKeyAsync<BusinessObject>(currentErrors, token, "BusinessObject", _data.BusinessObject);
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
            return await Task.FromResult(new Output<BusinessObjectType_CreateOutput>(currentErrors, res));
        }

        public virtual async Task<Output> UpdateAsync(int _id, BusinessObjectType_UpdateInput_Data _data, CancellationToken token = default)
        {
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Update operation below
                // CUSTOM_CODE_END
                BusinessObjectType obj = await ctx.FindEntityAsync<BusinessObjectType>(currentErrors, token, _id);
                var entry = ctx.Entry(obj);
                entry.CurrentValues.SetValues(_data);
                await ctx.ValidateKeyAsync<BusinessObject>(currentErrors, token, "BusinessObject", _data.BusinessObject);
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
                BusinessObjectType obj = await ctx.FindEntityAsync<BusinessObjectType>(currentErrors, token, _id);
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

        public virtual async Task<Output<ICollection<BusinessObjectType_ReadEnumsOutput>>> ReadEnumsAsync(CancellationToken token = default)
        {
            ICollection<BusinessObjectType_ReadEnumsOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for ReadEnums operation below
                // CUSTOM_CODE_END
                var src = from obj in ctx.BusinessObjectType select obj;

                // CUSTOM_CODE_START: add custom filter criteria to the source query for ReadEnums operation below
                // src = src.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new BusinessObjectType_ReadEnumsOutput() {
                              // CUSTOM_CODE_START: set the EnumType output parameter of ReadEnums operation below
                              EnumType = BusinessObjects.EnumName + obj.BusinessObject, // CUSTOM_CODE_END
                              Id = obj.Id,
                              Stub = obj.Stub,
                              Description = obj.Description,
                              Active = obj.Active,
                          };

                // CUSTOM_CODE_START: add custom filter criteria to the result query for ReadEnums operation below
                // qry = qry.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                currentErrors.AbortIfHasErrors();
                res = await qry.ToListAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<ICollection<BusinessObjectType_ReadEnumsOutput>>(currentErrors, res));
        }

        public virtual async Task<Output<ICollection<BusinessObjectType_ReadListOutput>>> ReadListAsync(BusinessObjectType_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            ICollection<BusinessObjectType_ReadListOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for ReadList operation below
                // CUSTOM_CODE_END
                var src = from obj in ctx.BusinessObjectType select obj;

                // CUSTOM_CODE_START: add custom filter criteria to the source query for ReadList operation below
                // src = src.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new BusinessObjectType_ReadListOutput() {
                              Id = obj.Id,
                              BusinessObject = obj.BusinessObject,
                              Stub = obj.Stub,
                              Description = obj.Description,
                              Active = obj.Active,
                          };

                // Result filter
                if (_criteria != null)
                {
                    qry = AddClause(qry, "BusinessObject", o => o.BusinessObject, _criteria.BusinessObjectOperator, _criteria.BusinessObject, _criteria.BusinessObject2);
                    qry = AddClause(qry, "Stub", o => o.Stub, _criteria.StubOperator, _criteria.Stub);
                    qry = AddClause(qry, "Description", o => o.Description, _criteria.DescriptionOperator, _criteria.Description);
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
            return await Task.FromResult(new Output<ICollection<BusinessObjectType_ReadListOutput>>(currentErrors, res));
        }
    }
}