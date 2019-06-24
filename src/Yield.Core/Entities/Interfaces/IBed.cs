using System.Collections.Generic;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public interface IBed : IEntity
    {
         string PlotId { get; set; }
         IEnumerable<string> Crops { get; set; }
    }
}