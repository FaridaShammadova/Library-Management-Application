using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library__Management_Application.DTOs.BorrowerDTOs
{
    public class BorrowerUpdateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}