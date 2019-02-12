using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yield.Core.Entities;
using Yield.Core.Services;

namespace Yield.Web.Controllers
{
    [Route("api/Allotment/{allotmentId}/Plot/{plotId}/[controller]")]
    public class BedController : Controller
    {
        public readonly IBedService bedService;

        public BedController(IBedService bedService)
        {
            this.bedService = bedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> Get(Guid bedId)
        {
            return Ok(await this.bedService.GetBeds(bedId));
        }

        /// <summary>
        /// Gets a bed for the given ID.
        /// </summary>
        /// <returns>The requested bed.</returns>
        /// <response code="200">The requested bed.</response>
        /// <response code="204">The bed for that Id does not exist.</response>   
        [HttpGet("{bedId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Bed>> Get([FromRoute] Guid plotId, [FromRoute] Guid bedId)
        {
            if(plotId == Guid.Empty) {
                return BadRequest("Must be a valid plot.");
            }
            
            var id = await this.bedService.GetBed(plotId);
            if(bedId == null)
            {
                return NoContent();
            } 
            else {
                return Ok(bedId);
            }
        }
    }

}
