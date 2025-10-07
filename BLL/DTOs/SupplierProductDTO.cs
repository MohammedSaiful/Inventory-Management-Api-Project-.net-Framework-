using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SupplierProductDTO
    {
        public List<ProductDTO> Products { get; set; }
        public SupplierProductDTO() 
        {
            Products = new List<ProductDTO>();
        }
    }
}
