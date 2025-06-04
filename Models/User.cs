using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_C.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagana")]
        [MinLength(4, ErrorMessage = "Minimum 4 znaki")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
