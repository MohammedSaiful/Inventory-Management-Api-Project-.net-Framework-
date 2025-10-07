using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>, IProductFeature
    {
        public bool Create(Product obj)
        {
            db.Products.Add(obj);
            return db.SaveChanges() >0;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            db.Products.Remove(obj);
            return db.SaveChanges() >0;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public bool Update(Product obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() >0;
        }

        public List<Product> GetCategory(string category)
        {
            var CategoryProduct = from p in db.Products 
                                  where p.Category == category
                                  select p;
            return CategoryProduct.ToList();
        }

        public List<Product> GetLowStock(int threshold)
        {
            var LowerProduct = from p in db.Products
                               where p.Quantity < threshold
                               select p;
            return LowerProduct.ToList();
        }

        public List<Product> GetExpiredProducts()
        {
            var ExpProduct = from p in db.Products
                             where p.ExpiryDate < DateTime.Now
                             select p;
            return ExpProduct.ToList();
        }
    }
}
