using System.Threading.Tasks;
using Yield.Core.Entities.Interfaces;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;


namespace Yield.Application.Allotment
{
    public class AllotmentService : IAllotmentService
    {
        private readonly IRepository<IAllotment> allotmentRepository;

        public AllotmentService(IRepository<IAllotment> allotmentRepository)
        {
            this.allotmentRepository = allotmentRepository;
        }

        public async Task<IAllotment> GetAllotment(string id)
        {
            return await this.allotmentRepository.Get(id);
        }
    }
}