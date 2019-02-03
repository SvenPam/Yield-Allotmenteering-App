using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Infrastructure.Repositories
{
    public class CropRepository : ICropRepository
    {
        private readonly List<Crop> crops = new List<Crop> {
            new Crop{
                Id = Guid.NewGuid(),
                Name = "Potato",
                Description = "King Edward",
                Family = new Family{
                    Name = "Root"
                }
            },
             new Crop{
                Id = Guid.NewGuid(),
                Name = "Carrot",
                Description = "British Orange",
                Family = new Family{
                    Name = "Root"
                }
            },
             new Crop{
                Id = Guid.NewGuid(),
                Name = "Tomato",
                Description = "Big Juicy Red One",
                Family = new Family{
                    Name = "Umbelliferae"
                }
            }
        };

        public async Task<IEnumerable<Crop>> GetCrops()
        {
            return await Task.FromResult(this.crops);
        }
        public async Task<Crop> GetCrop(Guid id)
        {
            return await Task.FromResult(this.crops.FirstOrDefault(x => x.Id == id));
        }

    }
}