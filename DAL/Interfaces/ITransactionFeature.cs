using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITransactionFeature
    {
        List<Transaction> GetUser(string username);
        List<Transaction> GetProduct(int productId);
        List<Transaction> GetType(string type);
        int GetTotalStock(int productId);
    }
}
