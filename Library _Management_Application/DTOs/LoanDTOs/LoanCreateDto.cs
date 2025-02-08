using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.DTOs.LoanDTOs
{
    public class LoanCreateDto
    {
        public DateTime LoanDate { get; set; }
        public DateTime MustReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BorrowerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}