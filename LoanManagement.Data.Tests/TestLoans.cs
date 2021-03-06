using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LoanManagement.Data.Tests
{
    
    public class TestLoanRepository
    {
        private readonly ILoanRepository loanRepository;
        public TestLoanRepository() {
            var options = new DbContextOptionsBuilder<LoanManagementDBContext>()
                    .UseInMemoryDatabase(databaseName: "LoanManagement")
                    .Options;
            var context = new LoanManagementDBContext(options);
            loanRepository = new LoanRepository(context);
            DataSetup.Initialize(context);
            
        }

        [Fact]
        public async void TestLoans()
        {
            var loans = await loanRepository.GetLoans();
            Assert.NotNull(loans);

        }

        [Fact]
        public async void TestLoansBalance()
        {
            var loans = await loanRepository.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.Balance > 0, $"expecting nonzero balance amount. LoanId:{loan.LoanId}");
            }
        }

        [Fact]
        public async void TestLoanInterest()
        {
            var loans = await loanRepository.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.Interest > 0, $"expecting nonnegative Interest amount. LoanId:{loan.LoanId}");
            }
        }

        [Fact]
        public async void TestLoanEarlyPayment()
        {
            var loans = await loanRepository.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.EarlyPaymentFee > 0, $"expecting nonnegative EarlyPaymentFee amount. LoanId:{loan.LoanId}");
            }
        }

        [Fact]
        public async void TestLoanCarryOver()
        {
            var loans = await loanRepository.GetLoans();
            foreach (var loan in loans)
            {
                Assert.True(loan.CarryOverAmount == loan.Balance + loan.Interest + loan.EarlyPaymentFee, $"expecting total amount to include Interest and EarlyPaymentFee. LoanId:{loan.LoanId}");
            }
        }
    }
}
