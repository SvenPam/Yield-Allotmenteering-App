using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.Crop
{
    public class CropService: ICropService
    {
        private readonly ICropRepository cropRepository;

        public CropService(ICropRepository cropRepository)
        {
            this.cropRepository = cropRepository;
        }

        public async Task<IEnumerable<Core.Entities.Crop>> GetCrops()
        {
            return await this.cropRepository.GetCrops();
        }
        public async Task<Core.Entities.Crop> GetCrop(string id)
        {
            return await this.cropRepository.GetCrop(id);
        }
    }
}