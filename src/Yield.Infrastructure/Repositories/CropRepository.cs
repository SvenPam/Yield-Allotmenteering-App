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
                Id = new Guid("a4f66c66-3d87-4880-96de-a38897039bf6"),
                Name = "Potato",
                Description = "King Edward",
                Family = new Family{
                    Name = "Root"
                }
            },
             new Crop{
                Id = new Guid("dcaf8881-b607-45e5-8c1f-d853df381081"),
                Name = "Carrot",
                Description = "British Orange",
                Family = new Family{
                    Name = "Root"
                }
            },
             new Crop{
                Id = new Guid("f47a8b5b-6b20-4189-89cd-fbf13f99fce0"),
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