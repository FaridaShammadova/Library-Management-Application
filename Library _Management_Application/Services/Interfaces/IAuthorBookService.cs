using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorBookDTOs;
using Library__Management_Application.DTOs.LoanItemDTOs;

namespace Library__Management_Application.Services.Interfaces
{
    public interface IAuthorBookService
    {
        void Create(AuthorBookCreateDto authorBookCreateDto);
        //AuthorBookGetDto GetById(int id);
        //List<AuthorBookGetDto> GetAll();
        void Update(int id, AuthorBookUpdateDto authorBookUpdateDto);
        void Delete(int id);
    }
}
