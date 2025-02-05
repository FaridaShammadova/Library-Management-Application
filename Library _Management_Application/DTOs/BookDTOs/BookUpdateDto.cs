using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.DTOs.BookDTOs
{
    public class BookUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int PublishedYear { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
