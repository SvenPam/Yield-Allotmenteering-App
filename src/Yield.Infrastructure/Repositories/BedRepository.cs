using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Infrastructure.Repositories
{
    public class BedRepository : IBedRepository
    {
        private readonly List<Bed> beds = new List<Bed> 
        {
            new Bed
            {
                Id = new Guid("b2f5241b-dddc-477a-8c16-597947cd2172"),
                Plot = new Guid("92f4a547-5200-4dc1-8009-1c32818d8a4a"),
                Crops = new List<Guid> {
                    new Guid("a4f66c66-3d87-4880-96de-a38897039bf6"),
                    new Guid("f47a8b5b-6b20-4189-89cd-fbf13f99fce0")

                }
            },
            new Bed
            {
                Id = new Guid("f276198b-fbab-4e44-8712-3aecdf5700dd"),
                Plot = new Guid("92f4a547-5200-4dc1-8009-1c32818d8a4a"),
                Crops = new List<Guid> {
                    new Guid("a4f66c66-3d87-4880-96de-a38897039bf6"),
                    new Guid("dcaf8881-b607-45e5-8c1f-d853df381081")

                }
            }
        };
        public async Task<IEnumerable<Bed>> GetBeds(Guid plot)
        {
            return await Task.FromResult(this.beds);
        }
        public async Task<Bed> GetBed(Guid plot)
        {
            return await Task.FromResult(this.beds.FirstOrDefault(x => x.Plot == plot));
        }

    }
}