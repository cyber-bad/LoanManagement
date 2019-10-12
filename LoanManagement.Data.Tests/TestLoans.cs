using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoanManagement.Data.Tests
{
    [TestClass]
    public class TestLoanRepository
    {
        private readonly ILoanRepository loanRepository;
        public TestLoanRepository(ILoanRepository repository)
        {
            loanRepository = repository;
        }

        [TestMethod]
        public async void TestLoans()
        {
            var loans = await loanRepository.GetLoans();
            Assert.IsNotNull(loans, "expecting at least one loan");
            foreach (var loan in loans)
            {
                Assert.IsTrue(loan.Balance > 0, $"expecting nonzero balance amount. LoanId:{loan.LoanId}");
                Assert.IsTrue(loan.Interest > 0, $"expecting nonnegative Interest amount. LoanId:{loan.LoanId}");
                Assert.IsTrue(loan.EarlyPaymentFee > 0, $"expecting nonnegative EarlyPaymentFee amount. LoanId:{loan.LoanId}");
                Assert.IsTrue(loan.CarryOverAmount == loan.Balance+ loan.Interest+loan.EarlyPaymentFee, $"expecting total amount to include Interest and EarlyPaymentFee. LoanId:{loan.LoanId}");
            }
        }
    }
}
