using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.BorrowerDTOs;
using Library__Management_Application.Models;

namespace Library__Management_Application.Services.Interfaces
{
    public interface IBorrowerService
    {
        void Create(BorrowerCreateDto borrowerCreateDto);
        BorrowerGetDto GetById(int id);
        List<BorrowerGetDto> GetAll();
        void Update(int id, BorrowerUpdateDto borrowerUpdateDto);
        void Delete(int id);
    }
}
