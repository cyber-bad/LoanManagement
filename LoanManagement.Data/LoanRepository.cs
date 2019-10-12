using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoanManagement.Data
{
    public class LoanRepository : ILoanRepository
    {

        private readonly LoanManagementDBContext loanContext;

        public LoanRepository(LoanManagementDBContext context)
        {
            loanContext = context;
        }

        public async Task<IEnumerable<Model.Loan>> GetLoans()
        {
            var loans = await loanContext.Loan.ToListAsync();

            return loans.Select( l=>
                new Model.Loan()
                {
                    LoanId = l.LoanId,
                    Balance = l.Balance,
                    EarlyPaymentFee = l.EarlyPaymentFee,
                    Interest = l.Interest,
                    Name = l.Name
                }
            );
        }

    }
}
