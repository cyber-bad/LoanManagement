using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Data
{

    public class Loan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LoanId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public decimal EarlyPaymentFee { get; set; }
        public decimal CarryOverAmount { get { return Balance + EarlyPaymentFee + Interest; } }
    }
}
