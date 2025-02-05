using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.DTOs.AuthorBookDTOs
{
    public class AuthorBookGetDto
    {
        public int Id { get; set; }
        public Author? Author { get; set; }
        public Book? Book { get; set; }
        public bool IsDeleted { get; set; }
    }
}
