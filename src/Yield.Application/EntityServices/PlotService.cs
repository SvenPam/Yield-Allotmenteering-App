using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.EntityServices
{
    public class PlotService : IPlotService
    {
        private readonly IRepository<Plot> plotRepository;

        public PlotService(IRepository<Plot> plotRepository)
        {
            this.plotRepository = plotRepository;
        }

        public async Task<Plot> GetPlot(string plotId)
        {
            return await this.plotRepository.Get(plotId);
        }
    }
}