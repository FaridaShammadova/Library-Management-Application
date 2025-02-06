using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.DTOs.BookDTOs;
using Library__Management_Application.Models;

namespace Library__Management_Application.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Book? GetBookById(int id);
        public List<Book> GetBookAll();
        public List<BookGetDto> FilterByTitle(string title);
        //public List<BookGetDto> FilterBooksByAuthor(string authorName);
    }
}
