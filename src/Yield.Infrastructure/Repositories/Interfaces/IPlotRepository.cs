using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Infrastructure.Repositories.Interfaces
{
    public interface IPlotRepository
    {
        Task<IEnumerable<Plot>> GetPlots(Guid allotmentId);
        Task<Plot> GetPlot(Guid allotmentId, Guid id);
    }
}
