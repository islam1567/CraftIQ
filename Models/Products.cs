using System.Text.Json.Serialization;

namespace CraftIQ.Models
{
    public class Products : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public float Wieght { get; set; }
        public float Hieght { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public List<Category>? Categories { get; set; }
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
    }
}
