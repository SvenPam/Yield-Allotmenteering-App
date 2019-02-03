using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yield.Core.Entities;
using Yield.Core.Services;

namespace Yield.Web.Controllers
{
    [Route("api/[controller]")]
    public class AllotmentController : Controller
    {
        public readonly IAllotmentService allotmentService;

        public AllotmentController(IAllotmentService allotmentService)
        {
            this.allotmentService = allotmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allotment>>> Get()
        {
            return Ok(await this.allotmentService.GetAllotments());
        }

        /// <summary>
        /// Gets a allotment for the given ID.
        /// </summary>
        /// <returns>The requested allotment.</returns>
        /// <response code="200">The requested allotment.</response>
        /// <response code="204">The allotment for that Id does not exist.</response>   
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Allotment>> Get([FromRoute]Guid id)
        {
            if(id == Guid.Empty) {
                return BadRequest("Must be a valid Guid.");
            }

            var allotment = await this.allotmentService.GetAllotment(id);
            if(allotment == null)
            {
                return NoContent();
            } 
            else {
                return Ok(allotment);
            }
        }
    }

}
