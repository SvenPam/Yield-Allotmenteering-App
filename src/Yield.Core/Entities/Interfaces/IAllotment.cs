using System.Collections.Generic;

namespace Yield.Core.Entities.Interfaces
{
    public interface IAllotment : IEntity
    {
        string Name { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        IEnumerable<string> Plots { get; set; }
    }
}