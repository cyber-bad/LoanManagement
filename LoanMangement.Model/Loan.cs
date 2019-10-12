using System;

namespace LoanManagement.Model
{
    public class Loan
    {
        public int LoanId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public decimal EarlyPaymentFee { get; set; }
        public decimal CarryOverAmount { get { return Balance + EarlyPaymentFee + Interest; } }
    }
}
