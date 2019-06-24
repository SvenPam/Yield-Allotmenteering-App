using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface IAllotmentService
    {
        Task<Allotment> GetAllotment(string id);
        Task<Allotment> AddAllotment(Allotment allotment);
    }
}