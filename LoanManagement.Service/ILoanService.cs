using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Service
{
    public interface ILoanService
    {
        Task<IEnumerable<Model.Loan>> GetLoans();

    }
}
