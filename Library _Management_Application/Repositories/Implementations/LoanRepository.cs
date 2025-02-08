using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Data;
using Library__Management_Application.Models;
using Library__Management_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Library__Management_Application.Repositories.Implementations
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        private readonly AppDbContext context;
        public LoanRepository()
        {
            context = new AppDbContext();
        }

        public Loan? GetLoanById(int id)
            => context.Loan
            .Include(x => x.Borrower)
            .Include(x => x.LoanItems)
            .Where(x => x.IsDeleted == false)
            .FirstOrDefault(x => x.Id == id);

        public List<Loan> GetLoanAll()
            => context.Loan
            .Include(x => x.Borrower)
            .Include(x => x.LoanItems)
            .Where(x => x.IsDeleted == false)
            .ToList();
    }
}