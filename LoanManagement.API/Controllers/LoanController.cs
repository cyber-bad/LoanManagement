using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Model;
using LoanManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoanManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {

        private readonly ILoanService loanService;
        public LoanController(ILoanService loansService)
        {
            loanService = loansService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            var loans = await loanService.GetLoans();

            return Ok(loans);

        }

       
    }
}
