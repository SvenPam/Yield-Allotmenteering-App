using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Infrastructure.Repositories.Interfaces
{
    public interface IBedRepository
    {
        Task<IEnumerable<Bed>> GetBeds(Guid plot);
        Task<Bed> GetBed(Guid plot);
    }
}