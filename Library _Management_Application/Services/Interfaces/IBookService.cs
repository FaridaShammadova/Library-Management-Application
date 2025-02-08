using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.DTOs.BookDTOs;
using Library__Management_Application.Models;

namespace Library__Management_Application.Services.Interfaces
{
    public interface IBookService
    {
        void Create(BookCreateDto bookCreateDto);
        BookGetDto GetById(int id);
        List<BookGetDto> GetAll();
        void Update(int id, BookUpdateDto bookUpdateDto);
        void Delete(int id);
        public List<BookGetDto> FilterByTitle(string title);
    }
}