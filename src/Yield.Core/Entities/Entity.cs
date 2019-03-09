using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public string Id { get; set; }
    }
}