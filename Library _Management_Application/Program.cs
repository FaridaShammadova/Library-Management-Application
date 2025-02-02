using System.Numerics;
using Library__Management_Application.DTOs.AuthorDTOs;
using Library__Management_Application.DTOs.BookDTOs;
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
            IAuthorService authorService = new AuthorService();
            IBookService bookService = new BookService();
            IBorrowerService borrowerService = new BorrowerService();

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

                Console.WriteLine("\nBook menu:");
                Console.WriteLine("6 - Create book");
                Console.WriteLine("7 - Get book by id");
                Console.WriteLine("8 - Get all books");
                Console.WriteLine("9 - Update book");
                Console.WriteLine("10 - Delete book");

                //Console.WriteLine("\nBorrower menu:");
                //Console.WriteLine("11 - Create borrower");
                //Console.WriteLine("12 - Get borrower by id");
                //Console.WriteLine("13 - Get all borrowers");
                //Console.WriteLine("14 - Update borrower");
                //Console.WriteLine("15 - Delete borrower");

                Console.WriteLine("0 - Exit");

                Console.WriteLine("\nEnter input:");
                string? input = Console.ReadLine();
                try
                {
                    CheckInput(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                switch (input)
                {
                    case "1":
                    AuthorNameCreateCase:
                        Console.WriteLine("Enter author name:");
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

                    case "2":
                    AuthorGetByIdCase:
                        Console.WriteLine("Enter id:");
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

                    case "3":
                        List<AuthorGetDto> authors = authorService.GetAll();
                        if (authors.Count == 0)
                        {
                            Console.WriteLine("Empty list");
                        }
                        else
                        {
                            foreach (var authorItem in authors)
                            {
                                Console.WriteLine($"{authorItem.Id} - {authorItem.Name}");
                            }
                        }
                        break;

                    case "4":
                    AuthorUpdateCase:
                        Console.WriteLine("Enter id:");
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
                        Console.WriteLine("Enter new author name:");
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

                    case "5":
                    AuthorDeleteCase:
                        Console.WriteLine("Enter id:");
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

                    case "6":
                    BookNameCreateCase:
                        Console.WriteLine("Enter book title:");
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
                        Console.WriteLine("Enter book description:");
                        string? bookDescription = Console.ReadLine();

                        try
                        {
                            CheckString(bookDescription);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookDescriptionCreateCase;
                        }

                    BookPublishedYearCreateCase:
                        Console.WriteLine("Enter book published year:");
                        int bookPublishedYear = 0;
                        string? bookPublishedYearInput = Console.ReadLine();

                        try
                        {
                            bookPublishedYear = CheckInt(bookPublishedYearInput);
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

                    case "7":
                    BookGetByIdCase:
                        Console.WriteLine("Enter id:");
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
                            Console.WriteLine($"{book.Id} - {book.Title} - {book.Description} - {book.PublishedYear}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "8":
                        List<BookGetDto> books = bookService.GetAll();
                        if (books.Count == 0)
                        {
                            Console.WriteLine("Empty list");
                        }
                        else
                        {
                            foreach (var bookItem in books)
                            {
                                Console.WriteLine($"{bookItem.Id} - {bookItem.Title} - {bookItem.Description} - {bookItem.PublishedYear}");
                            }
                        }
                        break;

                    case "9":
                    BookUpdateCase:
                        Console.WriteLine("Enter id:");
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
                        Console.WriteLine("Enter new author name:");
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
                        Console.WriteLine("Enter new author name:");
                        string? updateBookDescription = Console.ReadLine();

                        try
                        {
                            CheckString(updateBookDescription);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookDescriptionUpdateCase;
                        }

                    BookPublishedYearUpdateCase:
                        Console.WriteLine("Enter book published year:");
                        int updateBookPublishedYear = 0;
                        string? updateBookPublishedYearInput = Console.ReadLine();

                        try
                        {
                            updateBookPublishedYear = CheckInt(updateBookPublishedYearInput);
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

                    case "10":
                    BookDeleteCase:
                        Console.WriteLine("Enter id:");
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

                    //case "11":
                    //    Console.WriteLine("Enter borrower name:");
                    //    string? borrowerName = Console.ReadLine();

                    //    Console.WriteLine("Enter borrower email:");
                    //    string? borrowerEmail = Console.ReadLine();

                    //    DateTime createDate = DateTime.UtcNow.AddHours(4);
                    //    DateTime updateDate = DateTime.UtcNow.AddHours(4);
                    //    bool isDeleted = false;

                    //    try
                    //    {
                    //        borrowerService.Create(new Borrower() {
                    //            Name = borrowerName,
                    //            Email =  borrowerEmail,
                    //            IsDeleted = isDeleted,
                    //            CreateDate = createDate,
                    //            UpdateDate = updateDate
                    //        });
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Console.WriteLine(ex.Message);
                    //    }
                    //    break;

                    //case "12":
                    //    Console.WriteLine("Enter id:");
                    //    int borrowerId = Convert.ToInt32(Console.ReadLine());
                    //    try
                    //    {
                    //        var borrower = borrowerService.GetById(borrowerId);
                    //        Console.WriteLine($"{borrower.Id} - {borrower.Name} - {borrower.Email}");
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Console.WriteLine(ex.Message);
                    //    }
                    //    break;

                    //case "13":
                    //    try
                    //    {
                    //        foreach (var borrowerItem in borrowerService.GetAll())
                    //        {
                    //            Console.WriteLine($"{borrowerItem.Id} - {borrowerItem.Name} - {borrowerItem.Email}");
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Console.WriteLine(ex.Message);
                    //    }
                    //    break;

                    //case "14":
                    //    Console.WriteLine("Enter id:");
                    //    int updateBorrowerId = Convert.ToInt32(Console.ReadLine());

                    //    Console.WriteLine("Enter borrower name:");
                    //    string? newBorrowerName = Console.ReadLine();

                    //    Console.WriteLine("Enter borrower email:");
                    //    string? newBorrowerEmail = Console.ReadLine();

                    //    try
                    //    {
                    //        borrowerService.Update(updateBorrowerId, new Borrower() { Name = newBorrowerName, Email = newBorrowerEmail });
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Console.WriteLine(ex.Message);
                    //    }
                    //    break;

                    //case "15":
                    //    Console.WriteLine("Enter id:");
                    //    int deleteBorrowerId = Convert.ToInt32(Console.ReadLine());

                    //    try
                    //    {
                    //        bookService.Delete(deleteBorrowerId);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Console.WriteLine(ex.Message);
                    //    }
                    //break;

                    case "0":
                        check = true;
                        Console.WriteLine("Process has ended.");
                        break;
                }

                Console.ReadKey();
            }
        }
        static void CheckInput(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidException("Input cannot be null or empty.");

            foreach (var chr in value)
            {
                if (!char.IsDigit(chr)) throw new InvalidException("Input must be number");
            }

            int number = Convert.ToInt32(value);

            if (number < 0) throw new InvalidException("Input cannot be negative.");

            //if(number > ) throw new InvalidException("Input cannot be must than .");
        }

        static int CheckInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidException("Id cannot be null or empty.");

            if (!int.TryParse(value, out int number)) throw new InvalidException("Id must be a valid number.");

            if (number < 0) throw new InvalidException("Id cannot be negative.");

            if (number == 0) throw new InvalidException("Id cannot be 0.");
            return number;

        }

        static string CheckString(string value)
        {
            return value;

        }
    }
}