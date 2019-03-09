using System.Collections.Generic;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public class Family : Entity, IFamily
    {
        public string Name { get; set; }
        public IEnumerable<Family> Likes { get; set; }
        public IEnumerable<Family> Dislikes { get; set; }
    }
}