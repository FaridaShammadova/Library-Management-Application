using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library__Management_Application.DTOs.LoanItemDTOs
{
    public class LoanItemUpdateDto
    {
        public int BookId { get; set; }
        public int LoanId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
