using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;


namespace Yield.Application.Allotment
{
    public class AllotmentService: IAllotmentService
    {
        private readonly IAllotmentRepository allotmentRepository;

        public AllotmentService(IAllotmentRepository allotmentRepository)
        {
            this.allotmentRepository = allotmentRepository;
        }
        public async Task<IEnumerable<Core.Entities.Allotment>> GetAllotments()
        {
            return await this.allotmentRepository.GetAllotments();
        }


        public async Task<Core.Entities.Allotment> GetAllotment(string id)
        {
            return await this.allotmentRepository.GetAllotment(id);
        }
    }
}