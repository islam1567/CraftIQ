namespace CraftIQ.Models
{
    public class OrderDetails : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Orders { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ProductId { get; set; }
        public Products Products { get; set; }
    }
}
