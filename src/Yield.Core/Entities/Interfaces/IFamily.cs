using System.Collections.Generic;

namespace Yield.Core.Entities.Interfaces
{
    public interface IFamily
    {
        string Name { get; set; }
        IEnumerable<Family> Likes { get; set; }
        IEnumerable<Family> Dislikes { get; set; }
    }
}