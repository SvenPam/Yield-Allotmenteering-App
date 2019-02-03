using System;
using System.Threading.Tasks;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;


namespace Yield.Application.Allotment
{
    public class AllotmentService: IAllotmentService
    {
        public readonly IAllotmentRepository allotmentRepository;

        public AllotmentService(IAllotmentRepository allotmentRepository)
        {
            this.allotmentRepository = allotmentRepository;
        }

        public async Task<Core.Entities.Allotment> GetAllotment(Guid id)
        {
            return await this.allotmentRepository.GetAllotment(id);
        }
    }
}