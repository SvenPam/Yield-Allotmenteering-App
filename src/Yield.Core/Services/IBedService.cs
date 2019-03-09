using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IBedService
    {
        Task<IBed> GetBed(string bedId);
    }
}