using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("User")]
        public string UserName { get; set; }
        public int Tran_Qty { get; set; }
        public string Tran_Type { get; set; }
        public DateTime Tran_Date {  get; set; }= DateTime.Now;
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
