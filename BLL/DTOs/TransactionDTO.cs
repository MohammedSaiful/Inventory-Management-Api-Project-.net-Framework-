using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public int Tran_Qty { get; set; }
        public string Tran_Type { get; set; }
        public DateTime Tran_Date { get; set; }
    }
}
