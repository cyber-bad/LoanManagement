using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Data
{
    public class LoanManagementDBContext : DbContext
    {
        public LoanManagementDBContext (DbContextOptions<LoanManagementDBContext> options)
            : base(options)
        {
        }
            
        public DbSet<Loan> Loan { get; set; }


    }   
}
