namespace Yield.Core.Entities.Interfaces
{
    public interface ICrop : IEntity
    {
        string Name { get; set; }
        Family Family { get; set; }
        PlantingPhase[] PlantingPhases { get; set; }
        string Description { get; set; }
        string ImageLink { get; set; }
    }
}