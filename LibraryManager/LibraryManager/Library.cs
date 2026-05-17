using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LibraryManager;

    class Library(IFileManager fileManager) : ILibrary
    {
        private readonly List<LibraryBook> _books = fileManager.LoadFromFile();
        

        public void AddBook(LibraryBook book)
        {
            _books.Add(book);
            fileManager.SaveToFile(_books);
        }
        public void RemoveBook(int isbn)
        {
            var bookToDelete = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($" Book with isbn: {isbn} was not found\n");

            _books.Remove(bookToDelete);
            fileManager.SaveToFile(_books);
        }

        public LibraryBook? GetBookByAuthorOrTitle(string query)
        {
            return _books.FirstOrDefault(b => b.Author == query || b.Title == query);
        }

       
        public List<LibraryBook> GetAllAvailableBooks()
        {
            return _books.Where(b => b.Status == Status.Available).ToList();
        }
        public void BorrowBook(int isbn) 
        {
            var bookToBorrow = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($" Book with isbn: {isbn} was not found\n");
            bookToBorrow.Status = Status.Borrowed;
            fileManager.SaveToFile(_books);
        }

        public void ReturnBook(int isbn)
            {
                var bookToReturn = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                    throw new Exception($" Book with isbn: {isbn} was not found\n");
                bookToReturn.Status = Status.Available;
                fileManager.SaveToFile(_books);
        }
    }

