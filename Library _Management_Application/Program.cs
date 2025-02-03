using System.Numerics;
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

                Console.WriteLine("\nBorrower menu:");
                Console.WriteLine("11 - Create borrower");
                Console.WriteLine("12 - Get borrower by id");
                Console.WriteLine("13 - Get all borrowers");
                Console.WriteLine("14 - Update borrower");
                Console.WriteLine("15 - Delete borrower");

                Console.WriteLine("0 - Exit");

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

                    case 6:
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
                            CheckString(bookDescription);
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
                            bookPublishedYear = CheckInt(bookPublishedYearInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto BookPublishedYearCreateCase;
                        }

                        //Console.WriteLine("Choose authors:");
                        //foreach (var authorItem in authorService.GetAll())
                        //{
                        //    Console.WriteLine($"{authorItem.Id} - {authorItem.Name}");
                        //}

                        //Console.WriteLine("Enter author ids(separate ids with commas):");
                        //int chooseAuthorId = 0;
                        //string? chooseAuthorIdInput = Console.ReadLine();

                        //List<int> selectedAuthorIds = new List<int>();
                        //try
                        //{
                        //    chooseAuthorId = CheckInt(chooseAuthorIdInput);
                        //    selectedAuthorIds = chooseAuthorIdInput
                        //        .Split(',')
                        //        .Select(id => id.Trim())
                        //        .Where(id => !string.IsNullOrWhiteSpace(id))
                        //        .Select(id => int.Parse(id))
                        //        .ToList();
                        //}
                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine(ex.Message);
                        //}

                        //var selectedAuthors = new List<Author>();
                        //foreach (var selectedAuthorId in selectedAuthorIds)
                        //{
                        //    var selectedAuthorGetDto = authorService.GetById(selectedAuthorId);
                        //    Author selectedAuthor = new Author()
                        //    {
                        //        Id = selectedAuthorGetDto.Id,
                        //        Name = selectedAuthorGetDto.Name
                        //    };

                        //    if (selectedAuthor != null)
                        //    {
                        //        selectedAuthors.Add(selectedAuthor);
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine($"Author with ID {selectedAuthorId} not found.");
                        //    }
                        //}

                        try
                        {
                            bookService.Create(new BookCreateDto()
                            {
                                Title = bookTitle,
                                Description = bookDescription,
                                PublishedYear = bookPublishedYear,
                                IsDeleted = false,
                                //Authors = selectedAuthors 
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 7:
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
                            Console.WriteLine($"{book.Id} - {book.Title} - {book.Description} - {book.PublishedYear}");
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 8:
                        List<BookGetDto> books = bookService.GetAll();
                        if (books.Count == 0)
                        {
                            Console.WriteLine("\nEmpty list");
                        }
                        else
                        {
                            foreach (var bookItem in books)
                            {
                                Console.WriteLine($"{bookItem.Id} - {bookItem.Title} - {bookItem.Description} - {bookItem.PublishedYear}");
                            }
                        }
                        break;

                    case 9:
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
                            CheckString(updateBookDescription);
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

                    case 10:
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

                    case 11:
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

                    case 12:
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

                    case 13:
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

                    case 14:
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

                    case 15:
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
                }

                Console.ReadKey();
            }
        }
        static int CheckInput(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidException("Input cannot be null or empty.");

            if (!int.TryParse(value, out int number)) throw new InvalidException("Input must be a valid number.");

            if (number < 0) throw new InvalidException("Input cannot be negative.");

            //if(number > ) throw new InvalidException("Input cannot be must than .");
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
    }
}