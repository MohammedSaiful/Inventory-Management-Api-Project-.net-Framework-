using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INotificationFeature
    {
        bool LowStockNotification(Product product, int threshold);
        bool ExpireNotification(Product product);
    }
}
