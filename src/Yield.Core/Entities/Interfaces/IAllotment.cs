using System;
using System.Collections.Generic;

namespace Yield.Core.Entities.Interfaces
{
    public interface IAllotment
    {
        string Name { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        IEnumerable<string> Plots { get; set; }
    }
}