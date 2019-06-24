using System.Collections.Generic;

namespace Yield.Core.Entities
{
    public class Bed : Entity, IBed
    {
        public string PlotId { get; set; }
        public IEnumerable<string> Crops { get; set; }
    }
}