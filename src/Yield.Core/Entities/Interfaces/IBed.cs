using System;
using System.Collections.Generic;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public class IBed
    {
        public Guid Plot { get; set; }
        public IEnumerable<Guid> Crops { get; set; }
    }
}