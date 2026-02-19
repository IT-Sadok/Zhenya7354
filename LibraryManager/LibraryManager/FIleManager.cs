using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LibraryManager
{
    static class FileManager
    {
        private readonly static string _path = "library.json";
        public static void SaveToFile(Book book)
        {
            string json = JsonSerializer.Serialize<Book>(book);
            File.WriteAllText(_path,json);
        }

        public static List<Book> LoadFromFile()
        {
            string json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }
    }
}
