using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Library__Management_Application.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<LoanItem> LoanItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= localhost\SQLEXPRESS01; Database=PB503LibraryApplication;
            Trusted_Connection=true; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}