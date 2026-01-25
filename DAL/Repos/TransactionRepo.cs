using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TransactionRepo : Repo, IRepo<Transaction, int, bool>, ITransactionFeature
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
        public List<Transaction> GetUser(string username)
        {
            var UserTrans = from t in db.Transactions
                            where t.UserName.Equals(username)
                            select t;
            return UserTrans.ToList();
        }

        public List<Transaction> GetProduct(int productId)
        {
            var ProductTrans = from t in db.Transactions
                               where t.ProductId == productId
                               select t;
            return ProductTrans.ToList();
        }

        public List<Transaction> GetType(string type)
        {
            var TypeTrans = from t in db.Transactions
                            where t.Tran_Type.Equals(type)
                            select t;
            return TypeTrans.ToList();
        }

        public int GetTotalStock(int productId)
        {
            //  Total IN - Total OUT
            var totalIn = (from t in db.Transactions
                           where t.ProductId == productId && t.Tran_Type == "IN"
                           select t.Tran_Qty).Sum();

            var totalOut = (from t in db.Transactions
                            where t.ProductId == productId && t.Tran_Type == "OUT"
                            select t.Tran_Qty).Sum();

            return totalIn - totalOut;
        }

        public List<Transaction> GetTopSelling()
        {
            var TopSelling = from t in db.Transactions
                             where t.Tran_Type == "OUT"
                             select t;
            return TopSelling.ToList();
        }
    }
}
