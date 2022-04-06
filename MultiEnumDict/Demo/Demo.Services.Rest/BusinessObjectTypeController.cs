//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Web API Controllers" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Demo.Services.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace Demo.Services.Rest
{
    public partial class BusinessObjectTypeController : BaseController
    {
        private readonly IBusinessObjectTypeService svc;

        public BusinessObjectTypeController(ErrorList errorList, ErrorParser errorParser, IBusinessObjectTypeService service)
            : base(errorList, errorParser)
        {
            svc = service;
        }

        ///<summary>
        /// Reads the values of a Business Object Type object by its key.
        ///</summary>
        [Route("business-object-type/{_id}")]
        [HttpGet]
        public async Task<ActionResult> ReadAsync([FromRoute] int _id, CancellationToken token = default)
        {
            ActionResult response;
            try
            {
                if (ModelState.IsValid)
                {
                    Output<BusinessObjectType_ReadOutput> output = await svc.ReadAsync(_id, token);
                    response = StatusCode((int)output.HttpStatus, output);
                    return response;
                }
                else
                {
                    currentErrors.AddModelErrors(ModelState);
                }
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            response = StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
            return response;
        }

        ///<summary>
        /// Creates a new Business Object Type object using the specified data.
        ///</summary>
        [Route("business-object-type")]
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] BusinessObjectType_CreateInput _data, CancellationToken token = default)
        {
            ActionResult response;
            try
            {
                if (ModelState.IsValid)
                {
                    Output<BusinessObjectType_CreateOutput> output = await svc.CreateAsync(_data, token);
                    response = StatusCode((int)output.HttpStatus, output);
                    return response;
                }
                else
                {
                    currentErrors.AddModelErrors(ModelState);
                }
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            response = StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
            return response;
        }

        ///<summary>
        /// Updates existing Business Object Type object using the specified data.
        ///</summary>
        [Route("business-object-type/{_id}")]
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromRoute] int _id, [FromBody] BusinessObjectType_UpdateInput_Data _data, CancellationToken token = default)
        {
            ActionResult response;
            try
            {
                if (ModelState.IsValid)
                {
                    Output output = await svc.UpdateAsync(_id, _data, token);
                    response = StatusCode((int)output.HttpStatus, output);
                    return response;
                }
                else
                {
                    currentErrors.AddModelErrors(ModelState);
                }
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            response = StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
            return response;
        }

        ///<summary>
        /// Deletes the specified Business Object Type object.
        ///</summary>
        [Route("business-object-type/{_id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromRoute] int _id, CancellationToken token = default)
        {
            ActionResult response;
            try
            {
                if (ModelState.IsValid)
                {
                    Output output = await svc.DeleteAsync(_id, token);
                    response = StatusCode((int)output.HttpStatus, output);
                    return response;
                }
                else
                {
                    currentErrors.AddModelErrors(ModelState);
                }
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            response = StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
            return response;
        }

        ///<summary>
        /// Reads a list of Business Object Type enums.
        ///</summary>
        [Route("business-object-type/enum")]
        [HttpGet]
        public async Task<ActionResult> ReadEnumsAsync(CancellationToken token = default)
        {
            ActionResult response;
            try
            {
                if (ModelState.IsValid)
                {
                    Output<ICollection<BusinessObjectType_ReadEnumsOutput>> output = await svc.ReadEnumsAsync(token);
                    response = StatusCode((int)output.HttpStatus, output);
                    return response;
                }
                else
                {
                    currentErrors.AddModelErrors(ModelState);
                }
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            response = StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
            return response;
        }

        ///<summary>
        /// Reads a list of Business Object Type objects based on the specified criteria.
        ///</summary>
        [Route("business-object-type")]
        [HttpGet]
        public async Task<ActionResult> ReadListAsync([FromQuery] BusinessObjectType_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            ActionResult response;
            try
            {
                if (ModelState.IsValid)
                {
                    Output<ICollection<BusinessObjectType_ReadListOutput>> output = await svc.ReadListAsync(_criteria, token);
                    response = StatusCode((int)output.HttpStatus, output);
                    return response;
                }
                else
                {
                    currentErrors.AddModelErrors(ModelState);
                }
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            response = StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
            return response;
        }
    }
}