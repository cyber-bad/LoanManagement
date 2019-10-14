using LoanManagement.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LoanManagement.Service.Tests
{
    public class FakeTestLoans
    {
        List<Loan> fakeResult = null;
        Mock<LoanManagement.Data.ILoanRepository> loanRepo = null;
        public FakeTestLoans()
        {
            fakeResult = new List<Loan>();
            fakeResult.Add(new Loan() { Balance = 10, EarlyPaymentFee = 20, Interest = 30, LoanId = 1, Name = "Loan1" });
            var tcs = new TaskCompletionSource<IEnumerable<Loan>>();
            tcs.SetResult(fakeResult);

            loanRepo = new Mock<Data.ILoanRepository>();
            loanRepo.Setup(x => x.GetLoans()).Returns(tcs.Task);
        }

        [Fact]
        public async void TestLoans()
        {
            var loans = await loanRepo.Object.GetLoans();
            Assert.NotNull(loans);

        }

        [Fact]
        public async void TestLoansBalance()
        {
            var loans = await loanRepo.Object.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.Balance > 0, $"expecting nonzero balance amount. LoanId:{loan.LoanId}");
            }
        }

        [Fact]
        public async void TestLoanInterest()
        {
            var loans = await loanRepo.Object.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.Interest > 0, $"expecting nonnegative Interest amount. LoanId:{loan.LoanId}");
            }
        }

        [Fact]
        public async void TestLoanEarlyPayment()
        {
            var loans = await loanRepo.Object.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.EarlyPaymentFee > 0, $"expecting nonnegative EarlyPaymentFee amount. LoanId:{loan.LoanId}");
            }
        }

        [Fact]
        public async void TestLoanCarryOver()
        {
            var loans = await loanRepo.Object.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.CarryOverAmount == loan.Balance + loan.Interest + loan.EarlyPaymentFee, $"expecting total amount to include Interest and EarlyPaymentFee. LoanId:{loan.LoanId}");
            }
        }
    }
}
