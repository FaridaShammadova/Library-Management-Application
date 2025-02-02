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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext context;
        public BookRepository()
        {
            context = new AppDbContext();
        }

        public Book? GetBookById(int id)
            => context.Books
            .Include(x => x.Authors)
            .FirstOrDefault(x => x.Id == id);

        public List<Book> GetBookAll()
            => context.Books
            .Include(x => x.Authors)
            .ToList();
    }
}
