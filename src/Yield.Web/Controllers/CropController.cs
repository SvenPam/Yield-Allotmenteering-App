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
        public async Task<IEnumerable<Crop>> Get()
        {
            return await this.cropService.GetCrops();
        }

        [HttpGet("{id}")]
        public async Task<Crop> Get([FromRoute]Guid id)
        {
            return await this.cropService.GetCrop(id);
        }
    }

}
