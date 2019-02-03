using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Infrastructure.Repositories.Interfaces
{
    public interface IAllotmentRepository
    {
        Task<Allotment> GetAllotment(Guid Id);
    }
}