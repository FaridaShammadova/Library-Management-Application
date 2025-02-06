using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library__Management_Application.DTOs.BorrowerDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Repositories.Implementations;
using Library__Management_Application.Repositories.Interfaces;
using Library__Management_Application.Services.Interfaces;

namespace Library__Management_Application.Services.Implementations
{
    public class BorrowerService : IBorrowerService
    {
        IBorrowerRepository borrowerRepository;
        public BorrowerService()
        {
            borrowerRepository = new BorrowerRepository();
        }

        public void Create(BorrowerCreateDto borrowerCreateDto)
        {
            if (borrowerCreateDto is null) throw new NotFoundException("Borrower not found.");

            Borrower borrower = new Borrower()
            {
                Name = borrowerCreateDto.Name,
                Email = borrowerCreateDto.Email,
                IsDeleted = false,
                CreateDate = DateTime.UtcNow.AddHours(4),
                UpdateDate = DateTime.UtcNow.AddHours(4)
            };

            borrowerRepository.Create(borrower);
            int result = borrowerRepository.Commit();

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
            var borrower = borrowerRepository.GetById(id);
            if (borrower is null) throw new NotFoundException("Borrower not found.");

            borrower.IsDeleted = true;
            int result = borrowerRepository.Commit();

            if (result > 0)
            {
                Console.WriteLine($"{result} rows deleted.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public List<BorrowerGetDto> GetAll()
            => borrowerRepository.GetAll().Select(x => new BorrowerGetDto()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            }).ToList();

        public BorrowerGetDto GetById(int id)
        {
            var data = borrowerRepository.GetBorrowerById(id);
            if (data is null) throw new NotFoundException("Borrower not found.");

            BorrowerGetDto borrowerGetDto = new BorrowerGetDto()
            {
                Id = data.Id,
                Name = data.Name,
                Email = data.Email
            };

            return borrowerGetDto;
        }

        public void Update(int id, BorrowerUpdateDto borrowerUpdateDto)
        {
            if (borrowerUpdateDto is null) throw new NotFoundException("Borrower not found.");
            var data = borrowerRepository.GetById(id);
            if (data is null) throw new NotFoundException("Borrower not found.");

            data.Name = borrowerUpdateDto.Name;
            data.Email = borrowerUpdateDto.Email;
            data.UpdateDate = borrowerUpdateDto.UpdateDate;

            int result = borrowerRepository.Commit();

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
