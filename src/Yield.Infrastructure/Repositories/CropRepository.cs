using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Yield.Core.Entities;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Infrastructure.Repositories
{
    public class CropRepository : ICropRepository
    {
        private readonly List<Crop> crops = new List<Crop> 
        {
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
        private readonly IRepository<Crop> repository;

        public CropRepository(IRepository<Crop> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Crop>> GetCrops()
        {
            return await this.repository.GetItems();
        }
        public async Task<Crop> GetCrop(string id)
        {
            return await this.repository.Get(id);
        }
    }
}