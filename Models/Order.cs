using System.Text.Json.Serialization;

namespace CraftIQ.Models
{
    public class Order : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime OrderDat {  get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTime ExpectedDeliverydate { get; set; }
        public int OrderType { get; set; }
        public DateTime Receiveddate { get; set; }
        [JsonIgnore]
        public List<OrderDetails>? OrderDetails { get; set; }
        //public Guid SupplierId { get; set; }
        //public List<Supplier> Suppliers {  get; set; }
    }
}
