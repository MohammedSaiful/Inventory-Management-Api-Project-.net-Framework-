using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductFeature
    {
        List<Product> GetCategory(string category);
        List<Product> GetLowStock(int threshold);
        List<Product> GetExpiredProducts();

        List<Product> GetPaginated(int skip, int take);
        int GetTotalCount();
    }
}
