using System;
using System.Collections.Generic;

namespace Yield.Core.Entities.Interfaces
{
    public interface IPlot
    {
        Guid Id { get; set; }
        Guid AllotmentId { get; set; }
        string Name { get; set; }    
        int Number { get; set; }
        Dictionary<int, Dictionary<int, Guid>> Beds { get; set; }
    }
}