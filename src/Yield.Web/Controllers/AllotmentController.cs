using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Core.Entities.Interfaces;
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

        /// <summary>
        /// Gets an allotment for the given ID.
        /// </summary>
        /// <returns>The requested allotment.</returns>
        /// <response code="200">The requested allotment.</response>
        /// <response code="203">The allotment for that Id does not exist.</response>   
        /// <response code="400">Unique allotment ID must be provided.</response>   
        [HttpGet("{allotmentId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IAllotment>> Get([FromRoute]string allotmentId)
        {
            if (string.IsNullOrWhiteSpace(allotmentId))
            {
                return BadRequest("Must be a valid ID.");
            }

            var allotment = await this.allotmentService.GetAllotment(allotmentId);
            if (allotment == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(allotment);
            }
        }

        /// <summary>
        /// Creates a new allotment entity.
        /// </summary>
        /// <returns>The newly created allotment entity.</returns>
        /// <response code="201">Allotment entity created.</response>
        /// <response code="400">Allotment not to add not set in body.</response> 
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Allotment>> Post([FromBody] Allotment allotment)
        {
            if (allotment == null) {
                return BadRequest("Allotment to add must be set in body.");
            }

            allotment = await this.allotmentService.AddAllotment(allotment);

            return CreatedAtAction(nameof(Get), allotment);
        }
    }
}
