using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        void Create(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Delete(T entity);
        int Commit();
    }
}
