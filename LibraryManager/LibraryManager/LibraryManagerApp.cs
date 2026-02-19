using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    static class LibraryManagerApp
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Welcome to Library Manager");
            Console.WriteLine("Main menu: \n" +
                "1. Get all available books \n" +
                "2. Borrow book \n" +
                "3. Return book \n" +
                "4. Add book \n" +
                "5. Remove book \n" +
                "6. Find book \n" +
                "0. Exit \n");
        }
        public static int GetIsbnFromUser()
        { 
            Console.WriteLine("Provide book isbn number: ");
            return int.TryParse(Console.ReadLine(), out int result) ? result : 0;
        }
        public static Book GetBookInfoFromUser()
        {
            Console.WriteLine("Provide book isbn number: ");
            int isbn = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
            Console.WriteLine("Provide book title: ");
            string title = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Provide book author: ");
            string author = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Provide book publication year: ");
            int publicationYear = int.TryParse(Console.ReadLine(), out int yearResult) ? yearResult : 0;
            return new Book(isbn, title, author, publicationYear);
        }

        public static string GetSearchQueryFromUser()
        {
            Console.WriteLine("Provide book title or author: ");
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
