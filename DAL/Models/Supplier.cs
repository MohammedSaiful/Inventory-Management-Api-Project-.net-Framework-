using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }

        public Supplier() 
        {
            Products = new List<Product>();
        }

    }
}
