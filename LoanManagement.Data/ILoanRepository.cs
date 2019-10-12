using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model=LoanManagement.Model;

namespace LoanManagement.Data
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Model.Loan>> GetLoans();
    }
}
