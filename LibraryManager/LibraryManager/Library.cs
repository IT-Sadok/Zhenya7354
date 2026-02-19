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
                throw new Exception($" Book with isbn: {isbn} was not found");

            _books.Remove(bookToDelete);
            FileManager.SaveToFile(_books);
        }

        public Book GetBookByAuthor(string author)
        {
            return _books.FirstOrDefault(b => b.Author == author) ??
                throw new Exception($" Book with author: {author} was not found");
        }

        public Book GetBookByTitle(string title)
        {
            return _books.FirstOrDefault(b => b.Title == title) ??
                throw new Exception($" Book with title: {title} was not found");
        }

    }
}
