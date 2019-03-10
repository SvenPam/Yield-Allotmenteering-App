using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IPlotService
    {
        Task<Plot> GetPlot(string plotId);
    }
}