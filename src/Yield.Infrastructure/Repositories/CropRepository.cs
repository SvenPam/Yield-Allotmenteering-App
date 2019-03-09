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