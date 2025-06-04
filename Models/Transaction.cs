using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projekt_C.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        [EnumDataType(typeof(TransactionType))]
        public TransactionType TransactionType { get; set; }
    }
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer,
        Payment
    }
}
