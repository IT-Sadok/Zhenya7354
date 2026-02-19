
using LibraryManager;




class Program
{
    static void Main(string[] args)
    {
        int choice = 0, isbn = 0;
        Library library = new Library();

        do
        {
            try
            {
                LibraryManagerApp.DisplayMenu();
                Console.Write("Enter your choice: ");
                choice = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

                switch (choice)
                {
                    case 1:
                        var availableBooks = library.GetAllAvailableBooks();
                        if (availableBooks.Count == 0)
                        {
                            Console.WriteLine("No books available");
                            break;
                        }
                        foreach (var b in availableBooks)
                        {
                            b.DisplayInfo();
                        }
                        break;
                    case 2:
                        isbn = LibraryManagerApp.GetIsbnFromUser();
                        library.BorrowBook(isbn);
                        break;
                    case 3:
                        isbn = LibraryManagerApp.GetIsbnFromUser();
                        library.ReturnBook(isbn);
                        break;
                    case 4:
                        Book book = LibraryManagerApp.GetBookInfoFromUser();
                        library.AddBook(book);
                        break;
                    case 5:
                        LibraryManagerApp.GetIsbnFromUser();
                        library.RemoveBook(isbn);
                        break;
                    case 6:
                        string query = LibraryManagerApp.GetSearchQueryFromUser();
                        var foundBook = library.GetBookByAuthorOrTitle(query);
                        foundBook.DisplayInfo();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        } while (choice != 0);


    }
}
