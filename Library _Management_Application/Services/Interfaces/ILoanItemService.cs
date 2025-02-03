using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.LoanDTOs;
using Library__Management_Application.DTOs.LoanItemDTOs;

namespace Library__Management_Application.Services.Interfaces
{
    public interface ILoanItemService
    {
        void Create(LoanItemCreateDto loanItemCreateDto);
        LoanItemGetDto GetById(int id);
        List<LoanItemGetDto> GetAll();
        void Update(int id, LoanItemUpdateDto loanItemUpdateDto);
        void Delete(int id);
    }
}
