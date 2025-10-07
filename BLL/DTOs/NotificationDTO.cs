using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Massage { get; set; }
        public DateTime N_Date { get; set; }
        public int ProductId { get; set; }
    }
}
