using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TransactionRepo : Repo, IRepo<Transaction, int, bool>
    {
        public bool Create(Transaction obj)
        {
            db.Transactions.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex =Get(id);
            db.Transactions.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public List<Transaction> GetAll()
        {
            return db.Transactions.ToList();
        }

        public bool Update(Transaction obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
