using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Infrastructure.Repositories.Interfaces
{
    public interface IAllotmentRepository
    {
        Task<IEnumerable<Allotment>> GetAllotments();
        Task<Allotment> GetAllotment(string Id);
    }
}