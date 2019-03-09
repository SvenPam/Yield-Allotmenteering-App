using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.Plot
{
   public class PlotService: IPlotService
    {
        private readonly IPlotRepository plotRepository;

        public PlotService(IPlotRepository plotRepository)
        {
            this.plotRepository = plotRepository;
        }
        public async Task<IEnumerable<Core.Entities.Plot>> GetPlots(Guid allotmentId)
        {
            return await this.plotRepository.GetPlots(allotmentId);
        }


        public async Task<Core.Entities.Plot> GetPlot(Guid allotmentId, Guid id)
        {
            return await this.plotRepository.GetPlot(allotmentId, id);
        }
    }
}