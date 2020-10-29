using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Models;

namespace MVCWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // https://medium.com/@daniel.sagita/using-database-in-asp-net-core-f69f99048bb
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<LoanEvent> Loans { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
