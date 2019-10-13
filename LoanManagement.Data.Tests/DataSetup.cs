using LoanManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Data.Tests
{
    public class DataSetup
    {
        public static void Initialize(LoanManagementDBContext context)
        {

            if (context.Loan.Any())
            {
                return;
            }

            context.Loan.AddRange(
            new Loan
            {
                Name = "Travel Loan",
                Balance = 5000,
                EarlyPaymentFee = 100,
                Interest = 23.45m
            },
            new Loan
            {
                Name = "Movement Loan",
                Balance = 10000,
                EarlyPaymentFee = 50,
                Interest = 67.75m
            },
            new Loan
            {
                Name = "Equipment Loan",
                Balance = 3500,
                EarlyPaymentFee = 40,
                Interest = 12.35m
            });

            context.SaveChanges();
        }

    }
}
