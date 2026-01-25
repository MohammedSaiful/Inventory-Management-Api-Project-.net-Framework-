using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DashboardDTO
    {
        public int TotalProducts { get; set; }
        public double TotalInventoryValue { get; set; }
        public int LowStockCount { get; set; }
        public int TotalTransactionsToday { get; set; }
    }
}
