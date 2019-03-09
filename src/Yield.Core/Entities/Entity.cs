using Newtonsoft.Json;
using Yield.Core.Entities.Interfaces;

namespace Yield.Core.Entities
{
    public abstract class Entity : IEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}