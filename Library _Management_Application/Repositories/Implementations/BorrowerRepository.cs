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
    public class BorrowerRepository : GenericRepository<Borrower>, IBorrowerRepository
    {
        private readonly AppDbContext context;
        public BorrowerRepository()
        {
            context = new AppDbContext();
        }

        public Borrower? GetBorrowerById(int id)
            => context.Borrowers
            .Include(x => x.Loans)
            .Where(x => x.IsDeleted == false)
            .FirstOrDefault(x => x.Id == id);

        public List<Borrower> GetBorrowerAll()
            => context.Borrowers
            .Include(x => x.Loans)
            .Where(x => x.IsDeleted == false)
            .ToList();
    }
}