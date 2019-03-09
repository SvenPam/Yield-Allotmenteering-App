using System;

namespace Yield.Core.Entities.Interfaces
{
    public interface ICrop
    {
        string Name { get; set; }
        Family Family { get; set; }
        PlantingPhase[] PlantingPhases { get; set; }
        string Description { get; set; }
        string ImageLink { get; set; }

    }
}