using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.Models;

namespace Library__Management_Application.Services.Interfaces
{
    public interface IAuthorService
    {
        void Create(AuthorCreateDto authorGetDto);
        AuthorGetDto GetById(int id);
        List<AuthorGetDto> GetAll();
        void Update(int id, AuthorUpdateDto authorUpdateDto);
        void Delete(int id);
    }
}
