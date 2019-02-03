using System;
using System.Collections.Generic;

namespace Yield.Core.Entities.Interfaces
{
    public interface IAllotment
    {
        Guid Id { get; set; }
        string Name { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        IEnumerable<Guid> Plots { get; set; }
    }
}