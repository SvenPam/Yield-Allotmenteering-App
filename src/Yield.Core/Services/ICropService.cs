using System.Threading.Tasks;
using Yield.Core.Entities;

namespace Yield.Core.Services
{
    public interface ICropService
    {
        Task<Crop> GetCrop(string id);
    }
}