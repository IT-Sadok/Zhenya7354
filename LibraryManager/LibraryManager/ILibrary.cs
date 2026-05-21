using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager;

internal interface ILibrary
{
    public Task UpdateBookTitleAsync(LibraryBook bookToUpdate, int taskId);
    public Task AddBookAsync(LibraryBook book);
    public Task RemoveBookAsync(int isbn);
    public LibraryBook? GetBookByAuthorOrTitle(string query);
    public List<LibraryBook> GetAllAvailableBooks();
    public Task BorrowBookAsync(int isbn);
    public Task ReturnBookAsync(int isbn);
    public void DisplayBookTitle(LibraryBook book);
}
