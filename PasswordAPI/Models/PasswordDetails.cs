using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordAPI.Models
{
    public class PasswordDetails
    {
        [Key]
        public int PasswordDetailsId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PasswordOwnerName { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public int PasswordOwnersPhoneNr { get; set; }

        [Column(TypeName = "nvarchar(8)")]      //format dd/mm/yy
        public string ExpirationDate { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }
    }
}
