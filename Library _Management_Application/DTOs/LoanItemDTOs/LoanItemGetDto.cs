using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.DTOs.LoanItemDTOs
{
    public class LoanItemGetDto
    {
        public int Id { get; set; }
        public Book? Book { get; set; }
        public Loan? Loan { get; set; }
    }
}