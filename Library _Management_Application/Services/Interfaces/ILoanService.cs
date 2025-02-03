using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.DTOs.LoanDTOs;

namespace Library__Management_Application.Services.Interfaces
{
    public interface ILoanService
    {
        void Create(LoanCreateDto loanCreateDto);
        LoanGetDto GetById(int id);
        List<LoanGetDto> GetAll();
        void Update(int id, LoanUpdateDto loanUpdateDto);
        void Delete(int id);
    }
}
