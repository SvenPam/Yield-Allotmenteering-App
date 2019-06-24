using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IBedService
    {
        Task<Bed> GetBed(string plotId, string bedId);
    }
}