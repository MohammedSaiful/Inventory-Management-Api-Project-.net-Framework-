using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductTransactionDTO: ProductDTO
    {
        public List<TransactionDTO> Transactions { get; set; }
        public ProductTransactionDTO() 
        { 
            Transactions = new List<TransactionDTO>();
        
        }
    }
}
