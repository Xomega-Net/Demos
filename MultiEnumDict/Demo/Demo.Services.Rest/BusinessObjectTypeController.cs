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
        /// Reads a list of Business Object Type enums.
        ///</summary>
        [Route("business-object-type")]
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
    }
}