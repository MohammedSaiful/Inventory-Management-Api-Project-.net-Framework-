using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float UnitPrice {  get; set; }
        public float TotalPrice { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpiryDate { get; set; }


        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public Product()
        {
            Transactions = new List<Transaction>();
            Notifications = new List<Notification>();
        }
    }
}
