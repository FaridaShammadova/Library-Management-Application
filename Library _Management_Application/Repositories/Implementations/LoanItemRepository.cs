
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Data;
using Library__Management_Application.Models;
using Library__Management_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library__Management_Application.Repositories.Implementations
{
    public class LoanItemRepository : GenericRepository<LoanItem>, ILoanItemRepository
    {
        private readonly AppDbContext context;
        public LoanItemRepository()
        {
            context = new AppDbContext();
        }

        public LoanItem? GetLoanItemByIdWithBook(int id)
            => context.LoanItems
            .Include(x => x.Book)
            .FirstOrDefault(x => x.Id == id);

        public LoanItem? GetLoanItemByIdWithLoan(int id)
            => context.LoanItems
            .Include(x => x.Loan)
            .FirstOrDefault(x => x.Id == id);

        public List<LoanItem> GetLoanItemAllWithBook(int id)
            => context.LoanItems
            .Include(x => x.Book)
            .ToList();

        public List<LoanItem> GetLoanItemAllWithLoan(int id)
            => context.LoanItems
            .Include(x => x.Loan)
            .ToList();
    }
}
