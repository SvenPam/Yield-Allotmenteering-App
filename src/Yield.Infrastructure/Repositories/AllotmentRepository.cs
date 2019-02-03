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
        private readonly List<Allotment> allotments = new List<Allotment> {
            new Allotment{
                Id = new Guid("e41c7d47-4e30-4b6c-8d3c-558573e5e544"),
                Name = "Harris",
                Latitude = 53.371754,
                Longitude = -3.037435
            },
            new Allotment{
                Id = new Guid("d9a70d7a-6d79-4e24-a08a-d7a7041e080c"),
                Name = "Bebington Road",
                Latitude = 53.373606,
                Longitude = -3.021410
            }
        };
        public async Task<IEnumerable<Allotment>> GetAllotments()
        {
            return await Task.FromResult(this.allotments);
        }
        public async Task<Allotment> GetAllotment(Guid id)
        {
            return await Task.FromResult(this.allotments.FirstOrDefault(x => x.Id == id));
        }

    }
}