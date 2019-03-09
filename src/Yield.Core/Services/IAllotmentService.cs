using System.Threading.Tasks;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Services
{
    public interface IAllotmentService
    {
        Task<IAllotment> GetAllotment(string id);
    }
}