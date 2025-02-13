﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.Models;

namespace Library__Management_Application.Repositories.Interfaces
{
    public interface IBorrowerRepository : IGenericRepository<Borrower>
    {
        public Borrower? GetBorrowerById(int id);
        public List<Borrower> GetBorrowerAll();
    }
}