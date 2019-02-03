using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IPlotService
    {
        Task<IEnumerable<Plot>> GetPlots(Guid allotmentId);

        Task<Plot> GetPlot(Guid allotmentId, Guid id);
    }
}