using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserTransactionDTO : UserDTO
    {
        public List<TransactionDTO> Transactions {  get; set; }
        public UserTransactionDTO() 
        {
            Transactions = new List<TransactionDTO>();
        }
    }
}
