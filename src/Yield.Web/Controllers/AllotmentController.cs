using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        /// <summary>
        /// Gets a allotment for the given ID.
        /// </summary>
        /// <returns>The requested allotment.</returns>
        /// <response code="200">The requested allotment.</response>
        /// <response code="204">The allotment for that Id does not exist.</response>   
        [HttpGet("{allotmentId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Allotment>> Get([FromRoute]string allotmentId)
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
    }
}
