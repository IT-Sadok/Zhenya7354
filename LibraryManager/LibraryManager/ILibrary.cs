using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager;

internal interface ILibrary
{
    public void AddBook(Book book);
    public void RemoveBook(int isbn);
    public Book GetBookByAuthorOrTitle(string query);
    public List<Book> GetAllAvailableBooks();
    public void BorrowBook(int isbn);
    public void ReturnBook(int isbn);
}
