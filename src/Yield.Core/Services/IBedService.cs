using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IBedService
    {
        Task<IEnumerable<Bed>> GetBeds();
        Task<Bed> GetBed(Guid id);
    }
}