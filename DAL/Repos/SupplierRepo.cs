using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SupplierRepo : Repo, IRepo<Supplier, int, bool>
    {
        public bool Create(Supplier obj)
        {
            db.Suppliers.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            db.Suppliers.Remove(obj);
            return db.SaveChanges()>0;
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.Find(id);
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public bool Update(Supplier obj)
        {
            var ex =Get(obj.Id);  
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges()>0;
        }
    }
}
