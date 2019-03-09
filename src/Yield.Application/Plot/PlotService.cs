using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities.Interfaces;
using Yield.Core.Services;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Application.Plot
{
   public class PlotService: IPlotService
    {
        private readonly IRepository<IPlot> plotRepository;

        public PlotService(IRepository<IPlot> plotRepository)
        {
            this.plotRepository = plotRepository;
        }

        public async Task<IPlot> GetPlot(string plotId)
        {
            return await this.plotRepository.Get(plotId);
        }
    }
}