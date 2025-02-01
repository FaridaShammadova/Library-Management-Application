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
    public class AuthorService : IAuthorService
    {
        IAuthorRepository authorRepository;
        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        public void Create(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name)) throw new InvalidException("Author name cannot be null or empty.");
            if (author is null) throw new NotFoundException("Author not found.");

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
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            var data = authorRepository.GetById(id);
            if (data is null) throw new NotFoundException("Author not found.");

            authorRepository.Delete(data);
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

        public List<Author> GetAll()
        {
            var datas = authorRepository.GetAll();
            if (datas is null) throw new NotFoundException("Authors not found.");
            return datas;
        }

        public Author GetById(int id)
        {
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            var data = authorRepository.GetById(id);
            if (data is null) throw new NotFoundException("Author not found.");
            return data;
        }

        public void Update(int id, Author author)
        {
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            if (author is null) throw new NotFoundException("Author not found.");
            var data = authorRepository.GetById(id);
            if (data is null) throw new NotFoundException("Author not found.");

            data.Name = author.Name;
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
