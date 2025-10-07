using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Massage { get; set; }
        public DateTime N_Date { get; set; }= DateTime.Now;

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
