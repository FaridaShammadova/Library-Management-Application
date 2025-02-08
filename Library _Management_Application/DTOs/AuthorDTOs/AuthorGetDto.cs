using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.DTOs.AuthorDTOs
{
    public class AuthorGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}