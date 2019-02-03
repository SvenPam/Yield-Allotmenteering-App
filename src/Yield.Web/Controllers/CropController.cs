using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yield.Core.Entities;
using Yield.Core.Services;

namespace Yield.Web.Controllers
{
    [Route("api/[controller]")]
    public class CropController : Controller
    {
        private readonly ICropService cropService;

        public CropController(ICropService cropService)
        {
            this.cropService = cropService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crop>>> Get()
        {
            return Ok(await this.cropService.GetCrops());
        }

        /// <summary>
        /// Gets a crop for the given ID.
        /// </summary>
        /// <returns>The requested crop.</returns>
        /// <response code="200">The requested crop.</response>
        /// <response code="204">The crop for that Id does not exist.</response>   
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Crop>> Get([FromRoute]Guid id)
        {
            if(id == Guid.Empty) {
                return BadRequest("Must be a valid Guid.");
            }

            var crop = await this.cropService.GetCrop(id);
            if(crop == null)
            {
                return NoContent();
            } 
            else {
                return Ok(crop);
            }
        }
    }

}
