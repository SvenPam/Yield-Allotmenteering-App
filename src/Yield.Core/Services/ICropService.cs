using System.Threading.Tasks;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Services
{
    public interface ICropService
    {
        Task<ICrop> GetCrop(string id);
    }
}