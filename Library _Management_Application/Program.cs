﻿using System.Numerics;
using Library__Management_Application.DTOs.AuthorBookDTOs;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.DTOs.BookDTOs;
using Library__Management_Application.DTOs.BorrowerDTOs;
using Library__Management_Application.Models;
using Library__Management_Application.PB503Exceptions;
using Library__Management_Application.Services.Implementations;
using Library__Management_Application.Services.Interfaces;

namespace Library__Management_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBorrowerService borrowerService = new BorrowerService();

            bool check = false;

            while (!check)
            {
                Console.Clear();

                Console.WriteLine("1 - Author Menu");
                Console.WriteLine("2 - Book Menu");
                Console.WriteLine("3 - Borrower Menu");
                Console.WriteLine("4 - Author-book Menu");
                //Console.WriteLine("5 - Borrower Book");
                //Console.WriteLine("6 - Return Book");
                //Console.WriteLine("7 - Return the most borrowed book");
                //Console.WriteLine("8 - Return borrowers who delayed the book come");
                //Console.WriteLine("9 - Return borrowers who borrwed books");
                //Console.WriteLine("10 - Filter books by title");
                //Console.WriteLine("11 - Filter books by author");
                //Console.WriteLine("0 - Exit");

                CheckInputCase:
                Console.WriteLine("\nEnter input:");
                int input = 0;
                string? value = Console.ReadLine();
                try
                {
                    input = CheckInput(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto CheckInputCase;
                }

                switch (input)
                {
                    case 1:
                        AuthorMenu();
                        break;

                    case 2:
                        BookMenu();
                        break;

                    case 3:
                        BorrowerMenu();
                        break;

                    case 4:
                        AuthorBookMenu();
                        break;

                    case 5:
                        
                        break;

                    case 6:
                        
                        break;

                    case 7:
                        
                        break;

                    case 8:
                        
                        break;

                    case 9:
                        
                        break;

                    case 10:
                        
                        break;

                    case 11:

                        break;

                    case 0:
                        check = true;
                        Console.WriteLine("Process has ended.");
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void AuthorMenu()
        {
            IAuthorService authorService = new AuthorService();

            bool check = false;

            while (!check)
            {
                Console.Clear();

                Console.WriteLine("Author menu:");
                Console.WriteLine("1 - Create author");
                Console.WriteLine("2 - Get author by id");
                Console.WriteLine("3 - Get all authors");
                Console.WriteLine("4 - Update author");
                Console.WriteLine("5 - Delete author");
                Console.WriteLine("0 - Return Main Menu");

            CheckInputCase:
                Console.WriteLine("\nEnter input:");
                int input = 0;
                string? value = Console.ReadLine();
                try
                {
                    input = CheckInput(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto CheckInputCase;
                }

                switch (input)
                {
                    case 1:
                    AuthorNameCreateCase:
                        Console.WriteLine("\nEnter author name:");
                        string? authorName = Console.ReadLine();

                        try
                        {
                            CheckString(authorName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorNameCreateCase;
                        }

                        try
                        {
                            authorService.Create(new AuthorCreateDto()
                            {
                                Name = authorName,
                                IsDeleted = false
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                    AuthorGetByIdCase:
                        Console.WriteLine("\nEnter id:");
                        int authorId = 0;
                        string? authorIdInput = Console.ReadLine();

                        try
                        {
                            authorId = CheckInt(authorIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorGetByIdCase;
                        }

                        try
                        {
                            var author = authorService.GetById(authorId);
                            Console.WriteLine($"{author.Id} - {author.Name}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        List<AuthorGetDto> authors = authorService.GetAll();
                        if (authors.Count == 0)
                        {
                            Console.WriteLine("\nEmpty list");
                        }
                        else
                        {
                            foreach (var authorItem in authors)
                            {
                                Console.WriteLine($"{authorItem.Id} - {authorItem.Name}");
                            }
                        }
                        break;

                    case 4:
                    AuthorUpdateCase:
                        Console.WriteLine("\nEnter id:");
                        int updateAuthorId = 0;
                        string? updateAuthorIdInput = Console.ReadLine();

                        try
                        {
                            updateAuthorId = CheckInt(updateAuthorIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorUpdateCase;
                        }

                    AuthorNameUpdateCase:
                        Console.WriteLine("\nEnter new author name:");
                        string? updateAuthorName = Console.ReadLine();

                        try
                        {
                            CheckString(updateAuthorName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorNameUpdateCase;
                        }

                        try
                        {
                            authorService.Update(updateAuthorId, new AuthorUpdateDto()
                            {
                                Name = updateAuthorName,
                                UpdateDate = DateTime.UtcNow.AddHours(4)
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                    AuthorDeleteCase:
                        Console.WriteLine("\nEnter id:");
                        int deleteAuthorId = 0;
                        string? deleteAuthorIdInput = Console.ReadLine();

                        try
                        {
                            deleteAuthorId = CheckInt(deleteAuthorIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorDeleteCase;
                        }

                        try
                        {
                            authorService.Delete(deleteAuthorId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void BookMenu()
        {
            IBookService bookService = new BookService();

            bool check = false;

            while (!check)
            {
                Console.Clear();

                Console.WriteLine("\nBook menu:");
                Console.WriteLine("1 - Create book");
                Console.WriteLine("2 - Get book by id");
                Console.WriteLine("3 - Get all books");
                Console.WriteLine("4 - Update book");
                Console.WriteLine("5 - Delete book");
                Console.WriteLine("0 - Return Main Menu");

            CheckInputCase:
                Console.WriteLine("\nEnter input:");
                int input = 0;
                string? value = Console.ReadLine();
                try
                {
                    input = CheckInput(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto CheckInputCase;
                }

                switch (input)
                {
                    case 1:
                    BookNameCreateCase:
                        Console.WriteLine("\nEnter book title:");
                        string? bookTitle = Console.ReadLine();

                        try
                        {
                            CheckString(bookTitle);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookNameCreateCase;
                        }

                    BookDescriptionCreateCase:
                        Console.WriteLine("\nEnter book description:");
                        string? bookDescription = Console.ReadLine();

                        try
                        {
                            CheckDescription(bookDescription);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookDescriptionCreateCase;
                        }

                    BookPublishedYearCreateCase:
                        Console.WriteLine("\nEnter book published year:");
                        int bookPublishedYear = 0;
                        string? bookPublishedYearInput = Console.ReadLine();

                        try
                        {
                            bookPublishedYear = CheckPublishedYear(bookPublishedYearInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookPublishedYearCreateCase;
                        }

                        try
                        {
                            bookService.Create(new BookCreateDto()
                            {
                                Title = bookTitle,
                                Description = bookDescription,
                                PublishedYear = bookPublishedYear,
                                IsDeleted = false
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                    BookGetByIdCase:
                        Console.WriteLine("\nEnter id:");
                        int bookId = 0;
                        string? bookIdInput = Console.ReadLine();

                        try
                        {
                            bookId = CheckInt(bookIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookGetByIdCase;
                        }

                        try
                        {
                            var book = bookService.GetById(bookId);
                            if(book.AuthorBooks is null)
                            {
                                Console.WriteLine($"{book.Id} - {book.Title} - {book.Description} - {book.PublishedYear}");
                                Console.WriteLine("\nThe book has no authors.\n");
                            }
                            else
                            {
                                foreach (var author in book.AuthorBooks)
                                {
                                    Console.WriteLine($"{book.Id} - {book.Title} - {book.Description} - {book.PublishedYear} - {author.Author.Name}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        List<BookGetDto> books = bookService.GetAll();
                        if (books.Count == 0)
                        {
                            Console.WriteLine("\nEmpty list");
                        }
                        else
                        {
                            foreach (var bookItem in books)
                            {
                                if(bookItem.AuthorBooks is null)
                                {
                                    Console.WriteLine($"{bookItem.Id} - {bookItem.Title} - {bookItem.Description} - {bookItem.PublishedYear}");
                                    Console.WriteLine("\nThe book has no authors.\n");
                                }
                                else
                                {
                                    foreach (var author in bookItem.AuthorBooks)
                                    {
                                        Console.WriteLine($"{bookItem.Id} - {bookItem.Title} - {bookItem.Description} - {bookItem.PublishedYear} - {author.Author.Name}");
                                    }
                                }
                            }
                        }
                        break;

                    case 4:
                    BookUpdateCase:
                        Console.WriteLine("\nEnter id:");
                        int updateBookId = 0;
                        string? updateBookIdInput = Console.ReadLine();

                        try
                        {
                            updateBookId = CheckInt(updateBookIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookUpdateCase;
                        }

                    BookTitleUpdateCase:
                        Console.WriteLine("\nEnter new book title:");
                        string? updateBookTitle = Console.ReadLine();

                        try
                        {
                            CheckString(updateBookTitle);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookTitleUpdateCase;
                        }

                    BookDescriptionUpdateCase:
                        Console.WriteLine("\nEnter new book description:");
                        string? updateBookDescription = Console.ReadLine();

                        try
                        {
                            CheckDescription(updateBookDescription);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookDescriptionUpdateCase;
                        }

                    BookPublishedYearUpdateCase:
                        Console.WriteLine("\nEnter book published year:");
                        int updateBookPublishedYear = 0;
                        string? updateBookPublishedYearInput = Console.ReadLine();

                        try
                        {
                            updateBookPublishedYear = CheckPublishedYear(updateBookPublishedYearInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookPublishedYearUpdateCase;
                        }

                        try
                        {
                            bookService.Update(updateBookId, new BookUpdateDto()
                            {
                                Title = updateBookTitle,
                                Description = updateBookDescription,
                                PublishedYear = updateBookPublishedYear,
                                UpdateDate = DateTime.UtcNow.AddHours(4)
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                    BookDeleteCase:
                        Console.WriteLine("\nEnter id:");
                        int deleteBookId = 0;
                        string? deleteBookIdInput = Console.ReadLine();

                        try
                        {
                            deleteBookId = CheckInt(deleteBookIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookDeleteCase;
                        }

                        try
                        {
                            bookService.Delete(deleteBookId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void BorrowerMenu()
        {
            IBorrowerService borrowerService = new BorrowerService();

            bool check = false;

            while (!check)
            {
                Console.Clear();

                Console.WriteLine("\nBorrower menu:");
                Console.WriteLine("1 - Create borrower");
                Console.WriteLine("2 - Get borrower by id");
                Console.WriteLine("3 - Get all borrowers");
                Console.WriteLine("4 - Update borrower");
                Console.WriteLine("5 - Delete borrower");
                Console.WriteLine("0 - Return Main Menu");

            CheckInputCase:
                Console.WriteLine("\nEnter input:");
                int input = 0;
                string? value = Console.ReadLine();
                try
                {
                    input = CheckInput(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto CheckInputCase;
                }

                switch (input)
                {
                    case 1:
                    BorrowerNameCreateCase:
                        Console.WriteLine("\nEnter borrower name:");
                        string? borrowerName = Console.ReadLine();

                        try
                        {
                            CheckString(borrowerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BorrowerNameCreateCase;
                        }

                    BorrowerEmailCreateCase:
                        Console.WriteLine("\nEnter borrower email:");
                        string? borrowerEmail = Console.ReadLine();

                        try
                        {
                            CheckString(borrowerEmail);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BorrowerEmailCreateCase;
                        }

                        try
                        {
                            borrowerService.Create(new BorrowerCreateDto()
                            {
                                Name = borrowerName,
                                Email = borrowerEmail,
                                IsDeleted = false
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                    BorrowerGetByIdCase:
                        Console.WriteLine("\nEnter id:");
                        int borrowerId = 0;
                        string? borrowerIdInput = Console.ReadLine();

                        try
                        {
                            borrowerId = CheckInt(borrowerIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BorrowerGetByIdCase;
                        }

                        try
                        {
                            var borrower = borrowerService.GetById(borrowerId);
                            Console.WriteLine($"{borrower.Id} - {borrower.Name} - {borrower.Email}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        List<BorrowerGetDto> borrowers = borrowerService.GetAll();
                        if (borrowers.Count == 0)
                        {
                            Console.WriteLine("\nEmpty list");
                        }
                        else
                        {
                            foreach (var borrowerItem in borrowers)
                            {
                                Console.WriteLine($"{borrowerItem.Id} - {borrowerItem.Name} - {borrowerItem.Email}");
                            }
                        }
                        break;

                    case 4:
                    BorrowerUpdateCase:
                        Console.WriteLine("\nEnter id:");
                        int updateBorrowerId = 0;
                        string? updateBorrowerIdInput = Console.ReadLine();

                        try
                        {
                            updateBorrowerId = CheckInt(updateBorrowerIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BorrowerUpdateCase;
                        }

                    BorrowerNameUpdateCase:
                        Console.WriteLine("\nEnter new borrower name:");
                        string? updateBorrowerName = Console.ReadLine();

                        try
                        {
                            CheckString(updateBorrowerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BorrowerNameUpdateCase;
                        }

                    BorrowerEmailUpdateCase:
                        Console.WriteLine("\nEnter new borrower email:");
                        string? updateBorrowerEmail = Console.ReadLine();

                        try
                        {
                            CheckString(updateBorrowerEmail);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BorrowerEmailUpdateCase;
                        }

                        try
                        {
                            borrowerService.Update(updateBorrowerId, new BorrowerUpdateDto()
                            {
                                Name = updateBorrowerName,
                                Email = updateBorrowerEmail,
                                UpdateDate = DateTime.UtcNow.AddHours(4)
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                    BorrowerDeleteCase:
                        Console.WriteLine("\nEnter id:");
                        int deleteBorrowerId = 0;
                        string? deleteBorrowerIdInput = Console.ReadLine();

                        try
                        {
                            deleteBorrowerId = CheckInt(deleteBorrowerIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BorrowerDeleteCase;
                        }

                        try
                        {
                            borrowerService.Delete(deleteBorrowerId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void AuthorBookMenu()
        {
            IAuthorBookService authorBookService = new AuthorBookService();
            IAuthorService authorService = new AuthorService();
            IBookService bookService = new BookService();

            bool check = false;

            while (!check)
            {
                Console.Clear();

                Console.WriteLine("Author menu:");
                Console.WriteLine("1 - Create author-book relation");
                Console.WriteLine("2 - Update author-book relation");
                Console.WriteLine("3 - Delete author-book relation");
                Console.WriteLine("0 - Return Main Menu");

            CheckInputCase:
                Console.WriteLine("\nEnter input:");
                int input = 0;
                string? value = Console.ReadLine();
                try
                {
                    input = CheckInput(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto CheckInputCase;
                }

                switch (input)
                {
                    case 1:
                        Console.WriteLine("\nChoose author and book ids:");
                        Console.WriteLine("\nAuthors:");

                        foreach (var author in authorService.GetAll())
                        {
                            Console.WriteLine($"{author.Id} - {author.Name}");
                        }
                        Console.WriteLine("\nBooks:");

                        foreach (var book in bookService.GetAll())
                        {
                            Console.WriteLine($"{book.Id} - {book.Title} - {book.Description} - {book.PublishedYear}");
                        }

                    AuthorIdCreateCase:
                        Console.WriteLine("\nEnter author id:");
                        int authorId = 0;
                        string? authorIdInput = Console.ReadLine();

                        try
                        {
                            authorId = CheckInt(authorIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorIdCreateCase;
                        }

                    BookIdCreateCase:
                        Console.WriteLine("\nEnter book id:");
                        int bookId = 0;
                        string? bookIdInput = Console.ReadLine();

                        try
                        {
                            bookId = CheckInt(bookIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookIdCreateCase;
                        }

                        try
                        {
                            authorBookService.Create(new AuthorBookCreateDto()
                            {
                                AuthorId = authorId,
                                BookId = bookId,
                                IsDeleted = false
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                    AuthorBookUpdateCase:
                        Console.WriteLine("\nEnter id:");
                        int updateAuthorBookId = 0;
                        string? updateAuthorBookIdInput = Console.ReadLine();

                        try
                        {
                            updateAuthorBookId = CheckInt(updateAuthorBookIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorBookUpdateCase;
                        }

                    AuthorIdUpdateCase:
                        Console.WriteLine("\nEnter new author id:");
                        int updateAuthorId = 0;
                        string? updateAuthorIdInput = Console.ReadLine();

                        try
                        {
                            updateAuthorId = CheckInt(updateAuthorIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorIdUpdateCase;
                        }

                    BookIdUpdateCase:
                        Console.WriteLine("\nEnter new book id:");
                        int updateBookId = 0;
                        string? updateBookIdInput = Console.ReadLine();

                        try
                        {
                            updateBookId = CheckInt(updateBookIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookIdUpdateCase;
                        }

                        try
                        {
                            authorBookService.Update(updateAuthorBookId, new AuthorBookUpdateDto()
                            {
                                AuthorId = updateAuthorId,
                                BookId = updateBookId,
                                UpdateDate = DateTime.UtcNow.AddHours(4)
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                    AuthorBookDeleteCase:
                        Console.WriteLine("\nEnter id:");
                        int deleteAuthorBookId = 0;
                        string? deleteAuthorBookIdInput = Console.ReadLine();

                        try
                        {
                            deleteAuthorBookId = CheckInt(deleteAuthorBookIdInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto AuthorBookDeleteCase;
                        }

                        try
                        {
                            authorBookService.Delete(deleteAuthorBookId);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
                Console.ReadKey();
            }
        }

        static int CheckInput(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidException("Input cannot be null or empty.");

            if (!int.TryParse(value, out int number)) throw new InvalidException("Input must be a valid number.");

            if (number < 0) throw new InvalidException("Input cannot be negative.");
            return number;
        }

        static int CheckInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidException("Value cannot be null or empty.");

            if (!int.TryParse(value, out int number)) throw new InvalidException("Value must be a valid number.");

            if (number < 0) throw new InvalidException("Value cannot be negative.");

            if (number == 0) throw new InvalidException("Value cannot be 0.");
            return number;
        }

        static void CheckString(string value)
        {
            if(string.IsNullOrWhiteSpace(value)) throw new InvalidException("Value cannot be null or empty.");
        }

        static void CheckDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidException("Value cannot be null or empty.");

            if (int.TryParse(value, out _)) throw new InvalidException("Description cannot contain only numbers.");
        }

        static int CheckPublishedYear(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidException("Value cannot be null or empty.");

            if (!int.TryParse(value, out int number)) throw new InvalidException("Value must be a valid number.");

            if (number < 0) throw new InvalidException("Value cannot be negative.");

            if (number == 0) throw new InvalidException("Value cannot be 0.");

            if (number > 2025) throw new InvalidException("Value cannot be more than 2025.");
            return number;
        }
    }
}