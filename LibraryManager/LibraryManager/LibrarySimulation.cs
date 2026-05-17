using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager;

internal class LibrarySimulation
{ 
    private readonly SemaphoreSlim _semaphoreSlim;
    private readonly IFileManager _fileManager;
    private readonly List<LibraryBook> _books;

    public LibrarySimulation(int maxConcurrentOperations)
    {
        _semaphoreSlim = new SemaphoreSlim(maxConcurrentOperations, maxConcurrentOperations);
        _fileManager = new FileManager();
        _books = _fileManager.LoadFromFile();
    }

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

    public async Task RunSimulationAsync(int isbn)
    {
        var bookToUpdate = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($"Book with isbn {isbn} not found");
        var tasks = new List<Task>();

        for(int i = 0; i < 100; i++)
        {
            Task t = UpdateBookTitleAsync(bookToUpdate, i);
            tasks.Add(t);
            DisplayBookTitle(bookToUpdate);
        }
        await Task.WhenAll(tasks);

        _fileManager.SaveToFile(_books);
    }
    private void DisplayBookTitle(LibraryBook book)
    { 
        Console.WriteLine($"Book with isbn {book.Isbn} has title: {book?.Title ?? "Not found"}");
    }
}
