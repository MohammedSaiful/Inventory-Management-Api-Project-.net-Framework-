using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string tokenKey)
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(id));
        }

        public List<Token> GetAll()
        {
            throw new NotImplementedException();
        }

        public Token Update(Token obj)
        {
            var token = Get(obj.TokenKey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if(db.SaveChanges()>0) return token;
            return null;
        }

        public void Cleanup()
        {
            var expiredTokens = db.Tokens
                .Where(t => t.CreatedAt < DateTime.Now.AddMinutes(-20)
                    || t.DeletedAt != null)
                .ToList();

            foreach (var token in expiredTokens)
            {
                db.Tokens.Remove(token);
            }
            db.SaveChanges();
        }

    }
}
