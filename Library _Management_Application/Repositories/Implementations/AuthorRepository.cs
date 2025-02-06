using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Data;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library__Management_Application.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext context;
        public AuthorRepository()
        {
            context = new AppDbContext();
        }

        public Author? GetAuthorById(int id)
            => context.Authors
            .Include(x => x.Books)
            .Where(x => x.IsDeleted == false)
            .FirstOrDefault(x => x.Id == id);

        public List<Author> GetAuthorAll()
            => context.Authors
            .Include(x => x.Books)
            .Where(x => x.IsDeleted == false)
            .ToList();
    }
}