﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.Repositories.Interfaces
{
    public interface ILoanItemRepository : IGenericRepository<LoanItem>
    {
        public LoanItem? GetLoanItemById(int id);
        public List<LoanItem>? GetLoanItemAll();
    }
}