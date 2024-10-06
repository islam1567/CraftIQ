using System.Text.Json.Serialization;

namespace CraftIQ.Models
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<Products>? products { get; set; }
    }
}
