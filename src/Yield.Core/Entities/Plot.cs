using System;
using System.Collections.Generic;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public class Plot : Entity, IPlot
    {
        public string AllotmentId { get; set; }
        public string Name { get; set; }    
        public int Number { get; set; }
        public Dictionary<int, Dictionary<int, string>> Beds { get; set; }
    }
}