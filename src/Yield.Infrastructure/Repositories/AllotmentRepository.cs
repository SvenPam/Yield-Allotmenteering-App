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
        public AllotmentRepository (IRepository<Allotment> repository)
        {
            this.repository = repository;
        }
        private readonly IRepository<Allotment> repository;

        public async Task<IEnumerable<Allotment>> GetAllotments()
        {
            return await this.repository.GetItems();
        }
        public async Task<Allotment> GetAllotment(string id)
        {
            return await this.repository.Get(id);
        }
    }
}