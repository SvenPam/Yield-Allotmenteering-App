using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yield.Core.Entities;
using Yield.Core.Services;

namespace Yield.Web.Controllers
{
    [Route("api/[controller]")]
    public class BedController : Controller
    {
        public readonly IBedService bedService;

        public BedController(IBedService bedService)
        {
            this.bedService = bedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> Get(Guid plot)
        {
            return Ok(await this.bedService.GetBeds(plot));
        }

        /// <summary>
        /// Gets a bed for the given ID.
        /// </summary>
        /// <returns>The requested bed.</returns>
        /// <response code="200">The requested bed.</response>
        /// <response code="204">The bed for that Id does not exist.</response>   
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Bed>> Get([FromRoute]Guid plot, Guid crops)
        {
            if(plot == Guid.Empty) {
                return BadRequest("Must be a valid Guid.");
            }
            //TODO 
            var bed = await this.bedService.GetBed(plot);
            if(bed == null)
            {
                return NoContent();
            } 
            else {
                return Ok(bed);
            }
        }
    }

}
