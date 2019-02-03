using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IAllotmentService
    {
        Task<IEnumerable<Allotment>> GetAllotments();
        Task<Allotment> GetAllotment(Guid id);
    }
}