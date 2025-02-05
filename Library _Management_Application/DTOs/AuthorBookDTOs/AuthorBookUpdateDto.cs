using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library__Management_Application.DTOs.AuthorBookDTOs
{
    public class AuthorBookUpdateDto
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
