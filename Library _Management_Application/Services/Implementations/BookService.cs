using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.DTOs.BookDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Repositories.Implementations;
using Library__Management_Application.Repositories.Interfaces;
using Library__Management_Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library__Management_Application.Services.Implementations
{
    public class BookService : IBookService
    {
        IBookRepository bookRepository;
        public BookService()
        {
            bookRepository = new BookRepository();
        }

        public void Create(BookCreateDto bookCreateDto)
        {
            if (bookCreateDto is null) throw new NotFoundException("Book not found.");

            Book book = new Book()
            {
                Title = bookCreateDto.Title,
                Description = bookCreateDto.Description,
                PublishedYear = bookCreateDto.PublishedYear,
                IsDeleted = false,
                CreateDate = DateTime.UtcNow.AddHours(4),
                UpdateDate = DateTime.UtcNow.AddHours(4),
                Authors = bookCreateDto.Authors
            };

            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }

        public void Delete(int id)
        {
            var book = bookRepository.GetById(id);
            if (book is null) throw new NotFoundException("Book not found.");

            book.IsDeleted = true;
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

        public List<BookGetDto> GetAll()
            => bookRepository.GetAll().Select(x => new BookGetDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PublishedYear = x.PublishedYear
            }).ToList();



        public BookGetDto GetById(int id)
        {
            var data = bookRepository.GetBookById(id);
            if (data is null) throw new NotFoundException("Book not found.");

            BookGetDto bookGetDto = new BookGetDto()
            {
                Id = data.Id,
                Title = data.Title,
                Description = data.Description,
                PublishedYear = data.PublishedYear
            };

            return bookGetDto;
        }

        public void Update(int id, BookUpdateDto bookUpdateDto)
        {
            if (bookUpdateDto is null) throw new NotFoundException("Book not found.");
            var data = bookRepository.GetById(id);
            if (data is null) throw new NotFoundException("Book not found.");

            data.Title = bookUpdateDto.Title;
            data.Description = bookUpdateDto.Description;
            data.PublishedYear = bookUpdateDto.PublishedYear;
            data.UpdateDate = bookUpdateDto.UpdateDate;

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

        public List<BookGetDto> FilterByTitle(string title)
            => bookRepository.FilterByTitle(title);

        //public List<BookGetDto> FilterBooksByAuthor(string authorName)
        //    => bookRepository.FilterBooksByAuthor(authorName);
    }
}