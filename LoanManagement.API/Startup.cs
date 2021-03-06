﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LoanManagement.Data;
using LoanManagement.Service;
using LoanManagement.API.Extensions;

namespace LoanManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string allowCORS = "allowCORS";


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<LoanManagementDBContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("LoanManagementAPIContext")));

            services.AddDbContext<LoanManagementDBContext>(options =>
            options.UseInMemoryDatabase("LoanManagement"));

            services.AddTransient<ILoanService, LoanService>();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(
        options => options.WithOrigins("*").AllowAnyMethod()
    );
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler("/Error");

        }

    }
}
