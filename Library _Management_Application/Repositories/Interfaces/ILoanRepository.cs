using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.Repositories.Interfaces
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        public Loan? GetLoanById(int id);
        public List<Loan>? GetLoanAll();
    }
}