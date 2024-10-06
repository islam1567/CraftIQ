using System.Text.Json.Serialization;

namespace CraftIQ.Models
{
    public class Inventory : BaseEntity
    {
        public Guid Id {  get; set; }
        public Guid ProductId {  get; set; }
        public int Quantity {  get; set; }
        public int ReorderLevel {  get; set; }
        public string Location {  get; set; }
        public DateTime LastUpdate {  get; set; }
        [JsonIgnore]
        public List<Products>? Produces { get; set; }
    }
}
