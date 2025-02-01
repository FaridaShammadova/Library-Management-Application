using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Repositories.Implementations;
using Library__Management_Application.Repositories.Interfaces;
using Library__Management_Application.Services.Interfaces;

namespace Library__Management_Application.Services.Implementations
{
    public class BookService : IBookService
    {
        IBookRepository bookRepository;
        public BookService()
        {
            bookRepository = new BookRepository();
        }

        public void Create(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title)) throw new InvalidException("Book title cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(book.Description)) throw new InvalidException("Book description cannot be null or empty.");
            if (book.PublishedYear < 0) throw new InvalidException("Published year cannot be negative.");
            if (book is null) throw new NotFoundException("Book not found.");

            bookRepository.Create(book);
            int result = bookRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows created.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void Delete(int id)
        {
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            var data = bookRepository.GetById(id);
            if (data is null) throw new NotFoundException("Book not found.");

            bookRepository.Delete(data);
            int result = bookRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows deleted.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public List<Book> GetAll()
        {
            var datas = bookRepository.GetAll();
            if (datas is null) throw new NotFoundException("Books not found.");
            return datas;
        }

        public Book GetById(int id)
        {
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            var data = bookRepository.GetById(id);
            if (data is null) throw new NotFoundException("Book not found.");
            return data;
        }

        public void Update(int id, Book book)
        {
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            if (book is null) throw new NotFoundException("Book not found.");
            var data = bookRepository.GetById(id);
            if (data is null) throw new NotFoundException("Book not found.");

            data.Title = book.Title;
            data.Description = book.Description;
            data.PublishedYear = book.PublishedYear;
            int result = bookRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows updated.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
