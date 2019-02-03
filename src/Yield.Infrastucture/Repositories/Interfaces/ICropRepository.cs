using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Infrastucture.Repositories.Interfaces
{
    public interface ICropRepository
    {
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop> GetCrop(Guid id);
    }
}