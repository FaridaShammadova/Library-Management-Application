using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.BorrowerDTOs;
using Library__Management_Application.DTOs.LoanDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Repositories.Implementations;
using Library__Management_Application.Repositories.Interfaces;
using Library__Management_Application.Services.Interfaces;

namespace Library__Management_Application.Services.Implementations
{
    public class LoanService : ILoanService
    {
        ILoanRepository loanRepository;
        public LoanService()
        {
            loanRepository = new LoanRepository();
        }

        public void Create(LoanCreateDto loanCreateDto)
        {
            if (loanCreateDto is null) throw new InvalidException("Loan cannot be null or empty.");

            Loan loan = new Loan()
            {
                LoanDate = loanCreateDto.LoanDate,
                MustReturnDate = loanCreateDto.MustReturnDate,
                ReturnDate = loanCreateDto.ReturnDate,
                BorrowerId = loanCreateDto.BorrowerId,
                IsDeleted = false
            };

            loanRepository.Create(loan);
            int result = loanRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows created.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void Delete(int id)
        {
            var loan = loanRepository.GetById(id);
            if (loan is null) throw new NotFoundException("Loan not found.");

            loan.IsDeleted = true;
            int result = loanRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows deleted.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public List<LoanGetDto> GetAll()
            => loanRepository.GetAll().Select(x => new LoanGetDto()
            {
                Id = x.Id,
                LoanDate = DateTime.UtcNow.AddHours(4),
                MustReturnDate = DateTime.UtcNow.AddHours(4),
                ReturnDate = DateTime.UtcNow.AddHours(4)
            }).ToList();

        public LoanGetDto GetById(int id)
        {
            var data = loanRepository.GetById(id);
            if (data is null) throw new NotFoundException("Loan not found.");

            LoanGetDto loanGetDto = new LoanGetDto()
            {
                Id = data.Id,
                LoanDate = DateTime.UtcNow.AddHours(4),
                MustReturnDate = DateTime.UtcNow.AddHours(4),
                ReturnDate = DateTime.UtcNow.AddHours(4)
            };

            return loanGetDto;
        }

        public void Update(int id, LoanUpdateDto loanUpdateDto)
        {
            if (loanUpdateDto is null) throw new NotFoundException("Loan not found.");
            var data = loanRepository.GetById(id);
            if (data is null) throw new NotFoundException("Loan not found.");

            data.LoanDate = loanUpdateDto.LoanDate;
            data.MustReturnDate = loanUpdateDto.MustReturnDate;
            data.ReturnDate = loanUpdateDto.ReturnDate;
            data.BorrowerId = loanUpdateDto.BorrowerId;
            data.UpdateDate = loanUpdateDto.UpdateDate;

            int result = loanRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows updated.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
