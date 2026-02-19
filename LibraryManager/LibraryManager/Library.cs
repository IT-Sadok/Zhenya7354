using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    class Library
    {
        private List<Book> _books;
        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
        public void RemoveBook(int isbn)
        {
            var bookToDelete = _books.FirstOrDefault(b => b.Isbn == isbn) ?? 
                throw new Exception($" Book with isbn: {isbn} was not found");

               _books.Remove(bookToDelete);
        }
    }
}
