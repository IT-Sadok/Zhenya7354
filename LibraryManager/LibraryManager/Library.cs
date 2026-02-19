using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LibraryManager
{
    class Library
    {
        private List<Book> _books;
        public Library()
        {
            _books = FileManager.LoadFromFile();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            FileManager.SaveToFile(_books);
        }
        public void RemoveBook(int isbn)
        {
            var bookToDelete = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($" Book with isbn: {isbn} was not found\n");

            _books.Remove(bookToDelete);
            FileManager.SaveToFile(_books);
        }

        public Book GetBookByAuthorOrTitle(string query)
        {
            return _books.FirstOrDefault(b => b.Author == query || b.Title == query) ??
                throw new Exception($" Book with parameter: {query} was not found\n");
        }

       
        public List<Book> GetAllAvailableBooks()
        {
            return _books.Where(b => b.Status == Status.Available).ToList();
        }
        public void BorrowBook(int isbn)
        {
            var bookToBorrow = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($" Book with isbn: {isbn} was not found\n");
            bookToBorrow.Status = Status.Borrowed;
            Console.WriteLine("Book has been borrowed successfuly");
            FileManager.SaveToFile(_books);
        }

        public void ReturnBook(int isbn)
            {
                var bookToReturn = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                    throw new Exception($" Book with isbn: {isbn} was not found\n");
                bookToReturn.Status = Status.Available;
                Console.WriteLine("Book has been returned successfuly");
                FileManager.SaveToFile(_books);
        }
    }
}
