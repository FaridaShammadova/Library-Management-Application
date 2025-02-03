using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library__Management_Application.DTOs.LoanDTOs
{
    public class LoanUpdateDto
    {
        public DateTime LoanDate { get; set; }
        public DateTime MustReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BorrowerId { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
