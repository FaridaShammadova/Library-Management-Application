
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

        public LoanItem? GetLoanItemById(int id)
            => context.LoanItem
            .Include(x => x.Book)
            .Include(x => x.Loan)
            .Where(x => x.IsDeleted == false)
            .FirstOrDefault(x => x.Id == id);

        public List<LoanItem>? GetLoanItemAll()
            => context.LoanItem
            .Include(x => x.Book)
            .Include(x => x.Loan)
            .Where(x => x.IsDeleted == false)
            .ToList();
    }
}