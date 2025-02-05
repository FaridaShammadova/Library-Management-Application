using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.DTOs.AuthorBookDTOs
{
    public class AuthorBookCreateDto
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
