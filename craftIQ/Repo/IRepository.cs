using CraftIQ.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftIQ.Repo
{
    public interface IRepository<T>
    {
         List<T> GetAll();
         T GetById(Guid id);
         void Add(T t);
         void Update(Guid id, T t);
         void Delete(T t);
        
    }
}
