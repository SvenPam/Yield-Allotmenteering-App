using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.Bed
{
    public class BedService : IBedService
    {
        private readonly IRepository<IBed> BedRepository;

        public BedService(IRepository<IBed> BedRepository)
        {
            this.BedRepository = BedRepository;
        }

        public async Task<IBed> GetBed(string bedId)
        {
            return await this.BedRepository.Get(bedId);
        }
    }
}