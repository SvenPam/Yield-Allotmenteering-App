using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.EntityServices
{
    public class CropService : ICropService
    {
        private readonly IRepository<Crop> cropRepository;

        public CropService(IRepository<Crop> cropRepository)
        {
            this.cropRepository = cropRepository;
        }

        public async Task<Crop> GetCrop(string id)
        {
            return await this.cropRepository.Get(id);
        }
    }
}