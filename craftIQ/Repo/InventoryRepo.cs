using CraftIQ.Models;

namespace CraftIQ.Repo
{
    public class InventoryRepo : IRepository<Inventory>
    {
        public AppDbContext _context { get; }

        public InventoryRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public List<Inventory> GetAll()
        {
            var result = _context.Inventories.ToList();
            return (result);
        }
        public Inventory GetById(Guid id)
        {
            var result = _context.Inventories.FirstOrDefault(e => e.Id == id);
            return (result);
        }
        public void Add(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            _context.SaveChanges();
        }
        public void Update(Guid id, Inventory newinventory)
        {
            var old = _context.Inventories.FirstOrDefault(e => e.Id == id);
            old.Quantity = newinventory.Quantity;
            old.ReorderLevel = newinventory.ReorderLevel;
            old.Location = newinventory.Location;
            old.LastUpdate = newinventory.LastUpdate;
            old.CreatedOn = newinventory.CreatedOn;
            old.CreatedBy = newinventory.CreatedBy;
            old.ModifiedBy =newinventory.ModifiedBy;
            old.ModifiedOn =newinventory.ModifiedOn;
            _context.SaveChanges();
        }
        public void Delete(Inventory inventory)
        {
            _context.Remove(inventory);
            _context.SaveChanges();
        }
    }
}
