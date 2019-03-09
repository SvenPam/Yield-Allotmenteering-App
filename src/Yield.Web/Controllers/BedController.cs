using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        /// <summary>
        /// Gets a bed for the given ID.
        /// </summary>
        /// <returns>The requested bed.</returns>
        /// <response code="200">The requested bed.</response>
        /// <response code="204">The bed for that Id does not exist.</response>   
        [HttpGet("{bedId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Bed>> Get([FromRoute] string bedId)
        {
            if (!string.IsNullOrWhiteSpace(bedId))
            {
                return BadRequest("Must be a valid plot.");
            }

            var bed = await this.bedService.GetBed(bedId);

            if (bed == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(bed);
            }
        }
    }

}
