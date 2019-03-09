using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Core.Services;

namespace Yield.Web.Controllers
{
    [Route("api/[controller]")]
    public class PlotController : Controller
    {
        public readonly IPlotService plotService;
        public PlotController(IPlotService plotService)
        {
            this.plotService = plotService;
        }

        /// <summary>
        /// Gets a plot for the given ID.
        /// </summary>
        /// <returns>The requested plot.</returns>
        /// <response code="200">The requested plot.</response>
        /// <response code="204">The plot for that Id does not exist.</response>   

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Plot>> Get([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Must be a valid Guid.");
            }

            var plot = await this.plotService.GetPlot(id);

            if (plot == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(plot);
            }
        }
    }

}