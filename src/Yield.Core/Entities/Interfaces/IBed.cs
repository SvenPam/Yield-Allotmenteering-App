using System.Collections.Generic;

namespace Yield.Core.Entities
{
    public interface IBed
    {
         string Id { get; set; }
         string PlotId { get; set; }
         IEnumerable<string> Crops { get; set; }
    }
}