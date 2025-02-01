using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Create(Borrower borrower)
        {
            if (string.IsNullOrWhiteSpace(borrower.Name)) throw new InvalidException("Borrower name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(borrower.Email)) throw new InvalidException("Borrower email cannot be null or empty.");
            if (borrower is null) throw new NotFoundException("Borrower not found.");

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
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            var data = borrowerRepository.GetById(id);
            if (data is null) throw new NotFoundException("Borrower not found.");

            borrowerRepository.Delete(data);
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

        public List<Borrower> GetAll()
        {
            var datas = borrowerRepository.GetAll();
            if (datas is null) throw new NotFoundException("Borrowers not found.");
            return datas;
        }

        public Borrower GetById(int id)
        {
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            var data = borrowerRepository.GetById(id);
            if (data is null) throw new NotFoundException("Borrower not found.");
            return data;
        }

        public void Update(int id, Borrower borrower)
        {
            if (id < 1) throw new InvalidException("Id cannot be less than 1.");
            if (borrower is null) throw new NotFoundException("Borrower not found.");
            var data = borrowerRepository.GetById(id);
            if (data is null) throw new NotFoundException("Borrower not found.");

            data.Name = borrower.Name;
            data.Email = borrower.Email;
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
