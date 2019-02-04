using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.Bed
{
    public class BedService: IBedService
    {
        private readonly IBedRepository BedRepository;

        public BedService(IBedRepository BedRepository)
        {
            this.BedRepository = BedRepository;
        }
        public async Task<IEnumerable<Core.Entities.Bed>> GetBeds(Guid plot)
        {
            return await this.BedRepository.GetBeds(plot);
        }


        public async Task<Core.Entities.Bed> GetBed(Guid id)
        {
            return await this.BedRepository.GetBed(id);
        }
    }
}