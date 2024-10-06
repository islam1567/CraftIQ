using CraftIQ.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Repo
{
    public class CategoryRepo : IRepository<Category>
    {
        public AppDbContext _context { get; }

        public CategoryRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public List<Category> GetAll()
        {
            var result=_context.Categories.ToList();
            return(result);
        }
        public Category GetById(Guid id)
        {
            var result = _context.Categories.FirstOrDefault(e => e.Id==id);
            return (result);
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void Update(Guid id, Category newcategory)
        {
            var old = _context.Categories.FirstOrDefault(e => e.Id == id);
            old.Name=newcategory.Name;
            old.Description=newcategory.Description;
            old.CreatedOn=newcategory.CreatedOn;
            old.CreatedBy=newcategory.CreatedBy;
            old.ModifiedBy=newcategory.ModifiedBy;
            old.ModifiedOn=newcategory.ModifiedOn;
            _context.SaveChanges();
        }
        public void Delete (Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }
    }
}
