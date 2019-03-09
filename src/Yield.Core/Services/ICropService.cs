using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface ICropService
    {
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop> GetCrop(string id);
    }
}