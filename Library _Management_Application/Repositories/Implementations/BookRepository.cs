using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Data;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.DTOs.BookDTOs;
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
            .Where(x => x.IsDeleted == false)
            .FirstOrDefault(x => x.Id == id);

        public List<Book> GetBookAll()
            => context.Books
            .Include(x => x.Authors)
            .Where(x => x.IsDeleted == false)
            .ToList();

        public List<BookGetDto> FilterByTitle(string title)
            => context.Books
            .Where(b => b.Title.Contains(title))
            .Select(b => new BookGetDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                PublishedYear = b.PublishedYear
            }).ToList();
    }
}