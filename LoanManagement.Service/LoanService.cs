using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoanManagement.Data;
using LoanManagement.Model;

namespace LoanManagement.Service
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository loanRepository;
        public LoanService(ILoanRepository repository) {
            loanRepository = repository;
        }

        public Task<IEnumerable<Model.Loan>> GetLoans()
        {
            return loanRepository.GetLoans();
        }
    }
}
