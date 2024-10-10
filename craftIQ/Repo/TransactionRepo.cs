using CraftIQ.Models;
using System.Transactions;

namespace CraftIQ.Repo
{
    public class TransactionRepo : IRepository<Transactions>
    {
        public AppDbContext _context { get; }

        public TransactionRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public List<Transactions> GetAll()
        {
            var result = _context.Transactions.ToList();
            return (result);
        }
        public Transactions GetById(Guid id)
        {
            var result = _context.Transactions.FirstOrDefault(e => e.Id == id);
            return (result);
        }
        public void Add(Transactions transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public void Update(Guid id, Transactions newtransaction)
        {
            var old = _context.Transactions.FirstOrDefault(e => e.Id == id);
            old.TransactionDate = newtransaction.TransactionDate;
            old.TransactionType = newtransaction.TransactionType;
            old.Quantity = newtransaction.Quantity;
            old.Notes = newtransaction.Notes;
            old.CreatedOn = newtransaction.CreatedOn;
            old.CreatedBy = newtransaction.CreatedBy;
            old.ModifiedBy = newtransaction.ModifiedBy;
            old.ModifiedOn = newtransaction.ModifiedOn;
            _context.SaveChanges();
        }
        public void Delete(Transactions transactions)
        {
            _context.Remove(transactions);
            _context.SaveChanges();
        }
    }
}
