using CraftIQ.Models;

namespace CraftIQ.Repo
{
    public class OrderRepo : IRepository<Order>
    {
        public AppDbContext _context { get; }

        public OrderRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public List<Order> GetAll()
        {
            var result = _context.Orders.ToList();
            return (result);
        }
        public Order GetById(Guid id)
        {
            var result = _context.Orders.FirstOrDefault(e => e.Id == id);
            return (result);
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void Update(Guid id, Order neworder)
        {
            var old = _context.Orders.FirstOrDefault(e => e.Id == id);
            old.OrderDat = neworder.OrderDat;
            old.TotalAmount = neworder.TotalAmount;
            old.Status = neworder.Status;
            old.ExpectedDeliverydate = neworder.ExpectedDeliverydate;
            old.OrderType = neworder.OrderType;
            old.Receiveddate = neworder.Receiveddate;
            old.CreatedOn = neworder.CreatedOn;
            old.CreatedBy = neworder.CreatedBy;
            old.ModifiedBy = neworder.ModifiedBy;
            old.ModifiedOn = neworder.ModifiedOn;
            _context.SaveChanges();
        }
        public void Delete(Order order)
        {
            _context.Remove(order);
            _context.SaveChanges();
        }
    }
}
