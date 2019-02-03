using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yield.Core.Entities;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Infrastructure.Repositories
{
    public class PlotRepository : IPlotRepository
    {
        private readonly List<Plot> plots = new List<Plot> {
        new Plot {
        Id = new Guid("92f4a547-5200-4dc1-8009-1c32818d8a4a"),
        AllotmentId = new Guid("e41c7d47-4e30-4b6c-8d3c-558573e5e544"),
        Name = "Ste & Jax",
        Number = 123
        // Beds = 
        },
        new Plot {
        Id = new Guid("4cedffd1-89e9-412e-bffc-398648d84124"),
        AllotmentId = new Guid("e41c7d47-4e30-4b6c-8d3c-558573e5e544"),
        Name = "Person",
        Number = 125
        // Beds = 
        }
    };
    public async Task<IEnumerable<Plot>> GetPlots(Guid allotmentId)
    {
        return await Task.FromResult(this.plots.Where(x => x.AllotmentId == allotmentId));
    }
    public async Task<Plot> GetPlot(Guid allotmentId, Guid id)
    {
        return await Task.FromResult(this.plots.FirstOrDefault(x => x.AllotmentId == allotmentId && x.Id == id));
    }

}
}