using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LibraryManager;

class FileManager : IFileManager
{
    private readonly static string _path = "library.json";
    public void SaveToFile(IEnumerable<LibraryBook> books)
    {
        string json = JsonSerializer.Serialize(books);
        File.WriteAllText(_path, json);
    }

    public List<LibraryBook> LoadFromFile()
    {
        if (!File.Exists(_path)) return new List<LibraryBook>();
        string json = File.ReadAllText(_path);
        if (string.IsNullOrEmpty(json)) return new List<LibraryBook>();
        return JsonSerializer.Deserialize<List<LibraryBook>>(json) ?? new List<LibraryBook>();


    }
}

