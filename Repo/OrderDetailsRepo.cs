using CraftIQ.Models;

namespace CraftIQ.Repo
{
    public class OrderDetailsRepo : IRepository<OrderDetails>
    {
        public AppDbContext _context { get; }

        public OrderDetailsRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public List<OrderDetails> GetAll()
        {
            var result = _context.OrderDetails.ToList();
            return (result);
        }
        public OrderDetails GetById(Guid id)
        {
            var result = _context.OrderDetails.FirstOrDefault(e => e.Id == id);
            return (result);
        }
        public void Add(OrderDetails orderdetails)
        {
            _context.OrderDetails.Add(orderdetails);
            _context.SaveChanges();
        }
        public void Update(Guid id, OrderDetails neworderdetails)
        {
            var old = _context.OrderDetails.FirstOrDefault(e => e.Id == id);
            old.Quantity = neworderdetails.Quantity;
            old.TotalPrice = neworderdetails.TotalPrice;
            old.TotalPrice = neworderdetails.TotalPrice;
            old.CreatedOn = neworderdetails.CreatedOn;
            old.CreatedBy = neworderdetails.CreatedBy;
            old.ModifiedBy = neworderdetails.ModifiedBy;
            old.ModifiedOn = neworderdetails.ModifiedOn;
            _context.SaveChanges();
        }
        public void Delete(OrderDetails orderdetails)
        {
            _context.Remove(orderdetails);
            _context.SaveChanges();
        }
    }
}
