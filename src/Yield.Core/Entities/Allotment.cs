using System;
using System.Collections.Generic;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public class Allotment : Entity, IAllotment
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IEnumerable<Guid> Plots { get; set; }
    }
}