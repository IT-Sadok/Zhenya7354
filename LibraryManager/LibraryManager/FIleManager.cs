using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LibraryManager;

    class FileManager : IFileManager
    { 
        private readonly static string _path = "library.json";
        public void SaveToFile(IEnumerable<Book> books)
        {
            string json = JsonSerializer.Serialize(books);
            File.WriteAllText(_path, json);
        }

        public List<Book> LoadFromFile() 
        {
                string json = File.ReadAllText(_path);
            if (string.IsNullOrEmpty(json)) return new List<Book>();
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();

            
        }
    }

