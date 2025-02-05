using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorBookDTOs;
using Library__Management_Application.DTOs.BookDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Repositories.Implementations;
using Library__Management_Application.Repositories.Interfaces;
using Library__Management_Application.Services.Interfaces;

namespace Library__Management_Application.Services.Implementations
{
    public class AuthorBookService : IAuthorBookService
    {
        IAuthorBookRepository authorBookRepository;
        public AuthorBookService()
        {
            authorBookRepository = new AuthorBookRepository();
        }

        public void Create(AuthorBookCreateDto authorBookCreateDto)
        {
            if (authorBookCreateDto is null) throw new NotFoundException("Author or book not found.");

            AuthorBook authorBook = new AuthorBook()
            {
                AuthorId = authorBookCreateDto.AuthorId,
                BookId = authorBookCreateDto.BookId,
                IsDeleted = false,
                CreateDate = DateTime.UtcNow.AddHours(4),
                UpdateDate = DateTime.UtcNow.AddHours(4),
            };

            authorBookRepository.Create(authorBook);
            int result = authorBookRepository.Commit();

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
            var authorBook = authorBookRepository.GetById(id);
            if (authorBook is null) throw new NotFoundException("Author or book not found.");

            authorBook.IsDeleted = true;
            int result = authorBookRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows deleted.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        //public List<AuthorBookGetDto> GetAll()
        //    => authorBookRepository.GetAll().Select(x => new AuthorBookGetDto()
        //    {
        //        Id = x.Id,
        //        Author = x.Author,
        //        Book = x.Book
        //    }).ToList();

        //public AuthorBookGetDto GetById(int id)
        //{
        //    var data = authorBookRepository.GetById(id);
        //    if (data is null) throw new NotFoundException("Author or book not found.");

        //    AuthorBookGetDto authorBookGetDto = new AuthorBookGetDto()
        //    {
        //        Id = data.Id,
        //        Author = data.Author,
        //        Book = data.Book
        //    };

        //    return authorBookGetDto;
        //}

        public void Update(int id, AuthorBookUpdateDto authorBookUpdateDto)
        {
            if (authorBookUpdateDto is null) throw new NotFoundException("Author or book not found.");
            var data = authorBookRepository.GetById(id);
            if (data is null) throw new NotFoundException("Author or book not found.");

            data.AuthorId = authorBookUpdateDto.AuthorId;
            data.BookId = authorBookUpdateDto.BookId;
            data.UpdateDate = authorBookUpdateDto.UpdateDate;

            int result = authorBookRepository.Commit();

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
