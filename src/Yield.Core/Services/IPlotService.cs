using System.Threading.Tasks;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Services
{
    public interface IPlotService
    {
        Task<IPlot> GetPlot(string plotId);
    }
}