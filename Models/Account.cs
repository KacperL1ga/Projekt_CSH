using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projekt_C.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Numer konta jest wymagany")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Numer musi mieć 5 cyfr")]
        public string AccountNumber { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage ="Typ konta jest wymagany")]
        public string AccountType { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
