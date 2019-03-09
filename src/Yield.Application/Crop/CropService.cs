using System.Threading.Tasks;
using Yield.Core.Entities.Interfaces;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.Crop
{
    public class CropService : ICropService
    {
        private readonly IRepository<ICrop> cropRepository;

        public CropService(IRepository<ICrop> cropRepository)
        {
            this.cropRepository = cropRepository;
        }

        public async Task<ICrop> GetCrop(string id)
        {
            return await this.cropRepository.Get(id);
        }
    }
}