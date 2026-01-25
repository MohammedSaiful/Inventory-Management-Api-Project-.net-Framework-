using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TokenKey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [Required]
        public string RefreshToken { get; set; } // GUID string for refreshing
        [Required]
        public DateTime ExpiredAt { get; set; } // Expiry for the Refresh Token

        [Required]
        public string UserId {  get; set; }

        // add user type for role base login
        [Required]
        [StringLength (20)]
        public string UserType { get; set; }
    }
}
