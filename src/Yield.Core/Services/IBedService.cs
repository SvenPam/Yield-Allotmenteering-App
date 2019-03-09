using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IBedService
    {
        Task<IEnumerable<Bed>> GetBeds(Guid plot);
        Task<Bed> GetBed(Guid plot);
    }
}