using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Data;
using Library__Management_Application.Models;
using Library__Management_Application.Repositories.Interfaces;

namespace Library__Management_Application.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext context;
        public GenericRepository()
        {
            context = new AppDbContext();
        }

        public int Commit()
            => context.SaveChanges();

        public void Create(T entity)
            => context.Set<T>().Add(entity);

        public void Delete(T entity)
            => context.Set<T>().Remove(entity);

        public List<T> GetAll()
            => context.Set<T>().ToList();

        public T GetById(int id)
            => context.Set<T>().FirstOrDefault(x => x.Id == id);
    }
}
