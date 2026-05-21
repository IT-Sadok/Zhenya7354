using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager;

internal class LibrarySimulation
{ 
    private readonly IFileManager _fileManager;
    private readonly List<LibraryBook> _books;
    private readonly ILibrary _library;

    public LibrarySimulation(ILibrary library)
    {
        _fileManager = new FileManager();
        _books = _fileManager.LoadFromFile();
        _library = library;
    }


    public async Task RunSimulationAsync(int isbn)
    {
        var bookToUpdate = _books.FirstOrDefault(b => b.Isbn == isbn) ??
                throw new Exception($"Book with isbn {isbn} not found");
        var tasks = new List<Task>();

        for(int i = 0; i < 100; i++)
        {
            Task t = _library.UpdateBookTitleAsync(bookToUpdate, i);
            tasks.Add(t);
            _library.DisplayBookTitle(bookToUpdate);
        }
        await Task.WhenAll(tasks);

        _fileManager.SaveToFile(_books);
    }
    
}
