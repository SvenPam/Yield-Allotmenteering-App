using System;
using System.Collections.Generic;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public interface IBed
    {
         Guid Id { get; set; }
         Guid Plot { get; set; }
         IEnumerable<Guid> Crops { get; set; }
    }
}