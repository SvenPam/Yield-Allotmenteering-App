using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Infrastructure.Repositories
{
    public class AllotmentRepository : IAllotmentRepository
    {
        public readonly List<Allotment> allotment = new List<Allotment> {
            new Allotment{
                Id = new Guid("e41c7d47-4e30-4b6c-8d3c-558573e5e544"),
                Name = "Jax & Ste's Allotment",
                Latitude = 53.371754,
                Longitude = -3.037435
            }
        };
        public async Task<Allotment> GetAllotment(Guid id)
        {
            return await Task.FromResult(this.allotment.FirstOrDefault(x => x.Id == id));
        }

    }
}