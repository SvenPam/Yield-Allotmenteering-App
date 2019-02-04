using System;
using System.Collections.Generic;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public class Plot : IPlot
    {
        public Guid Id { get; set; }
        public Guid AllotmentId { get; set; }
        public string Name { get; set; }    
        public int Number { get; set; }
        public Dictionary<int, Dictionary<int, Guid>> Beds { get; set; }
    }
}