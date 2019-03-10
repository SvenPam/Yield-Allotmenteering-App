using System.Collections.Generic;

namespace Yield.Core.Entities.Interfaces
{
    public interface IPlot : IEntity
    {
        string AllotmentId { get; set; }
        string Name { get; set; }
        int Number { get; set; }
        Dictionary<int, Dictionary<int, string>> Beds { get; set; }
    }
}