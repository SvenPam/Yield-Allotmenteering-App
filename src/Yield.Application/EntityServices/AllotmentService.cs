using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Core.Entities.Interfaces;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;


namespace Yield.Application.EntityServices
{
    public class AllotmentService : IAllotmentService
    {
        private readonly IRepository<Allotment> allotmentRepository;

        public AllotmentService(IRepository<Allotment> allotmentRepository)
        {
            this.allotmentRepository = allotmentRepository;
        }

        public async Task<Allotment> AddAllotment(Allotment allotment)
        {
            return await this.allotmentRepository.Create(allotment) as Allotment;
        }

        public async Task<Allotment> GetAllotment(string id)
        {
            return await this.allotmentRepository.Get(id) as Allotment;
        }
    }
}