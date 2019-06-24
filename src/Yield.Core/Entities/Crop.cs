using System;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public class Crop : Entity, ICrop
    {
        public string Name { get; set; }
        public Family Family { get; set; }
        public PlantingPhase[] PlantingPhases { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }

    }
}