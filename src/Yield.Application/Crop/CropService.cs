using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Services;
using Yield.Infrastucture.Repositories.Interfaces;

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
        public async Task<Core.Entities.Crop> GetCrop(Guid id)
        {
            return await this.cropRepository.GetCrop(id);
        }
    }
}