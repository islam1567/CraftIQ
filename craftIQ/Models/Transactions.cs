using System.Text.Json.Serialization;

namespace CraftIQ.Models
{
    public class Transactions : BaseEntity
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public List<Products> Products { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        //public Guid EmployeeId { get; set; }
    }
}
