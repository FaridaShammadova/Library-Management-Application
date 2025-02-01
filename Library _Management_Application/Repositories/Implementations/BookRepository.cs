using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;
using Library__Management_Application.Repositories.Interfaces;

namespace Library__Management_Application.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
    }
}
