using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>, IAuthen<bool>
    {
        public bool GetAuthen(string username, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.Uname.Equals(username) && u.Password.Equals(password));
            if(data != null) return true; 
            return false;
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Get(id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        

        public User Update(User obj)
        {
            var ex = Get(obj.Uname);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0 ) return obj;
            return null;
        }
    }
}
