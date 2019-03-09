using System;
using System.Collections.Generic;

namespace Yield.Core.Entities.Interfaces
{
    public interface IPlot
    {
        string Id { get; set; }
        string AllotmentId { get; set; }
        string Name { get; set; }    
        int Number { get; set; }
        Dictionary<int, Dictionary<int, string>> Beds { get; set; }
    }
}