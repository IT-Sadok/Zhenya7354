using LibraryManager;




class Program
{
    static async Task Main(string[] args)
    {
        int choice = 0, isbn = 0;
        var fileManager = new FileManager();
        Library library = new Library(fileManager);
        LibrarySimulation librarySimulation = new LibrarySimulation(library);

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
                            LibraryManagerApp.DisplayBookInfo(b);
                        }
                        break;
                    case 2:
                        isbn = LibraryManagerApp.GetIsbnFromUser();
                        await library.BorrowBookAsync(isbn);
                        break;
                    case 3:
                        isbn = LibraryManagerApp.GetIsbnFromUser();
                        await library.ReturnBookAsync(isbn);
                        break;
                    case 4:
                        LibraryBook book = LibraryManagerApp.GetBookInfoFromUser();
                        await library.AddBookAsync(book);
                        break;
                    case 5:
                        isbn = LibraryManagerApp.GetIsbnFromUser();
                        await library.RemoveBookAsync(isbn);
                        break;
                    case 6:
                        string query = LibraryManagerApp.GetSearchQueryFromUser();
                        var foundBook = library.GetBookByAuthorOrTitle(query);
                        if(foundBook is null)
                        {
                            Console.WriteLine("No book found matching the query.");
                            break;
                        }
                        LibraryManagerApp.DisplayBookInfo(foundBook);
                        break;
                    case 7:
                        isbn = LibraryManagerApp.GetIsbnFromUser();
                        librarySimulation.RunSimulationAsync(isbn).Wait();
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
