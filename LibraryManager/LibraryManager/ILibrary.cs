using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager;

internal interface ILibrary
{
    public void AddBook(LibraryBook book);
    public void RemoveBook(int isbn);
    public LibraryBook? GetBookByAuthorOrTitle(string query);
    public List<LibraryBook> GetAllAvailableBooks();
    public void BorrowBook(int isbn);
    public void ReturnBook(int isbn);
}
