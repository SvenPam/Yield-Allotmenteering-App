using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.EntityServices
{
    public class BedService : IBedService
    {
        private readonly IRepository<Bed> BedRepository;

        public BedService(IRepository<Bed> BedRepository)
        {
            this.BedRepository = BedRepository;
        }

        public async Task<Bed> GetBed(string bedId)
        {
            return await this.BedRepository.Get(bedId);
        }
    }
}