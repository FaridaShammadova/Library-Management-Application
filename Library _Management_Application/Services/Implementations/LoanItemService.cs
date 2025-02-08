using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.LoanDTOs;
using Library__Management_Application.DTOs.LoanItemDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Repositories.Implementations;
using Library__Management_Application.Repositories.Interfaces;
using Library__Management_Application.Services.Interfaces;

namespace Library__Management_Application.Services.Implementations
{
    public class LoanItemService : ILoanItemService
    {
        ILoanItemRepository loanItemRepository;
        public LoanItemService()
        {
            loanItemRepository = new LoanItemRepository();
        }

        public void Create(LoanItemCreateDto loanItemCreateDto)
        {
            if (loanItemCreateDto is null) throw new InvalidException("Loan item cannot be null or empty.");

            LoanItem loanItem = new LoanItem()
            {
                BookId = loanItemCreateDto.BookId,
                LoanId = loanItemCreateDto.LoanId,
                IsDeleted = false
            };

            loanItemRepository.Create(loanItem);
            int result = loanItemRepository.Commit();

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
            var loanItem = loanItemRepository.GetLoanItemById(id);
            if (loanItem is null) throw new NotFoundException("Loan item not found.");

            loanItem.IsDeleted = true;
            int result = loanItemRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows deleted.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public List<LoanItemGetDto> GetAll()
            => loanItemRepository.GetLoanItemAll().Select(x => new LoanItemGetDto()
            {
                Id = x.Id,
                Book = x.Book,
                Loan = x.Loan
            }).ToList();

        public LoanItemGetDto GetById(int id)
        {
            var data = loanItemRepository.GetLoanItemById(id);
            if (data is null) throw new NotFoundException("Loan item not found.");

            LoanItemGetDto loanItemGetDto = new LoanItemGetDto()
            {
                Id = data.Id,
                Book = data.Book,
                Loan = data.Loan
            };

            return loanItemGetDto;
        }

        public void Update(int id, LoanItemUpdateDto loanItemUpdateDto)
        {
            if (loanItemUpdateDto is null) throw new NotFoundException("Loan item not found.");
            var data = loanItemRepository.GetLoanItemById(id);
            if (data is null) throw new NotFoundException("Loan item not found.");

            data.BookId = loanItemUpdateDto.BookId;
            data.LoanId = loanItemUpdateDto.LoanId;
            data.UpdateDate = loanItemUpdateDto.UpdateDate;

            int result = loanItemRepository.Commit();

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