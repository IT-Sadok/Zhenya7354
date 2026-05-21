using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LibraryManager;

class Library(IFileManager fileManager) : ILibrary
{
    private readonly List<LibraryBook> _books = fileManager.LoadFromFile();
    private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);


    public async Task UpdateBookTitleAsync(LibraryBook bookToUpdate, int taskId)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            bookToUpdate.Title = "Task " + taskId;
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
    public async Task AddBookAsync(LibraryBook book)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            _books.Add(book);
            fileManager.SaveToFile(_books);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
    public async Task RemoveBookAsync(int isbn)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            var bookToDelete = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($" Book with isbn: {isbn} was not found\n");

            _books.Remove(bookToDelete);
            fileManager.SaveToFile(_books);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    public LibraryBook? GetBookByAuthorOrTitle(string query)
    {
        return _books.FirstOrDefault(b => b.Author == query || b.Title == query);
    }


    public List<LibraryBook> GetAllAvailableBooks()
    {
        return _books.Where(b => b.Status == Status.Available).ToList();
    }
    public async Task BorrowBookAsync(int isbn)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            var bookToBorrow = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($" Book with isbn: {isbn} was not found\n");
            bookToBorrow.Status = Status.Borrowed;
            fileManager.SaveToFile(_books);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    public async Task ReturnBookAsync(int isbn)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            var bookToReturn = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($" Book with isbn: {isbn} was not found\n");
            bookToReturn.Status = Status.Available;
            fileManager.SaveToFile(_books);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
    public void DisplayBookTitle(LibraryBook book)
    {
        Console.WriteLine($"Book with isbn {book.Isbn} has title: {book?.Title ?? "Not found"}");
    }
}

