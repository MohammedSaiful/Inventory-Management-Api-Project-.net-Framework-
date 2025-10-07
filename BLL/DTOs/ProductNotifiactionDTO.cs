using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductNotifiactionDTO: ProductDTO
    {
        public List<NotificationDTO> Notifications { get; set; }

        public ProductNotifiactionDTO() 
        {
            Notifications = new List<NotificationDTO>();
        }
    }
}
