using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.DTOs.LoanItemDTOs
{
    public class LoanItemCreateDto
    {
        public int BookId { get; set; }
        public int LoanId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
