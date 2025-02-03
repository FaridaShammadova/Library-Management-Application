using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Repositories.Implementations;
using Library__Management_Application.Repositories.Interfaces;
using Library__Management_Application.Services.Interfaces;

namespace Library__Management_Application.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository authorRepository;
        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        public void Create(AuthorCreateDto authorGetDto)
        {
            if (authorGetDto is null) throw new NotFoundException("Author not found.");

            Author author = new Author()
            {
                Name = authorGetDto.Name,
                IsDeleted = authorGetDto.IsDeleted,
                CreateDate = DateTime.UtcNow.AddHours(4),
                UpdateDate = DateTime.UtcNow.AddHours(4),
            };

            authorRepository.Create(author);
            int result = authorRepository.Commit();

            if(result > 0)
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
            var author = authorRepository.GetById(id);
            if (author is null) throw new NotFoundException("Author not found.");
            author.IsDeleted = true;
            int result = authorRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows deleted.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public List<AuthorGetDto> GetAll()
            => authorRepository.GetAll().Select(x => new AuthorGetDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

        public AuthorGetDto GetById(int id)
        {
            var data = authorRepository.GetById(id);
            if (data is null) throw new NotFoundException("Author not found.");

            var authorGetDto = new AuthorGetDto()
            {
                Id = data.Id,
                Name = data.Name
            };
            return authorGetDto;
        }

        public void Update(int id, AuthorUpdateDto authorUpdateDto)
        {
            if (authorUpdateDto is null) throw new NotFoundException("Author not found.");
            var data = authorRepository.GetById(id);
            if (data is null) throw new NotFoundException("Author not found.");

            data.Name = authorUpdateDto.Name;
            data.UpdateDate = authorUpdateDto.UpdateDate;
            data.Books = authorUpdateDto.Books;
            int result = authorRepository.Commit();

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
