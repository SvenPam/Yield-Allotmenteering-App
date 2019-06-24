using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        /// <summary>
        /// Gets a crop for the given ID.
        /// </summary>
        /// <returns>The requested crop.</returns>
        /// <response code="200">The requested crop.</response>
        /// <response code="204">The crop for that Id does not exist.</response>   
        [HttpGet("{cropId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Crop>> Get([FromRoute]string cropId)
        {
            var crop = await this.cropService.GetCrop(cropId);

            if (crop == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(crop);
            }
        }
    }

}
