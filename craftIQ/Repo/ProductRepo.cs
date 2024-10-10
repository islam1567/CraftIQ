using CraftIQ.Models;

namespace CraftIQ.Repo
{
    public class ProductRepo : IRepository<Products>
    {
        public AppDbContext _context { get; }

        public ProductRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public List<Products> GetAll()
        {
            var result = _context.Products.ToList();
            return (result);
        }
        public Products GetById(Guid id)
        {
            var result = _context.Products.FirstOrDefault(e => e.Id == id);
            return (result);
        }
        public void Add(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
        }
        public void Update(Guid id, Products newproducts)
        {
            var old = _context.Products.FirstOrDefault(e => e.Id == id);
            old.Name = newproducts.Name;
            old.Description=newproducts.Description;
            old.UnitPrice = newproducts.UnitPrice;
            old.Width=newproducts.Width;
            old.Wieght=newproducts.Wieght;
            old.Hieght=newproducts.Hieght;
            old.Length=newproducts.Length;
            old.TaxCost=newproducts.TaxCost;
            old.ProductionCost=newproducts.ProductionCost;
            old.ProfitPerUnit=newproducts.ProfitPerUnit;
            old.CreatedBy=newproducts.CreatedBy;
            old.CreatedOn=newproducts.CreatedOn;
            old.ModifiedOn=newproducts.ModifiedOn;
            old.ModifiedBy=newproducts.ModifiedBy;
            _context.SaveChanges();
        }
        public void Delete(Products products)
        {
            _context.Remove(products);
            _context.SaveChanges();
        }
    }
}
