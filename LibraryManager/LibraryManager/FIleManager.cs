using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LibraryManager
{
    static class FileManager
    {
        static FileManager()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        private readonly static string _path = "library.json";
        public static void SaveToFile(List<Book> books)
        {
            string json = JsonSerializer.Serialize<List<Book>>(books);
            File.WriteAllText(_path, json);
        }

        public static List<Book> LoadFromFile()
        {
            
            
                string json = File.ReadAllText(_path);
            if (string.IsNullOrEmpty(json)) return new List<Book>();
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();

            
        }
    }
}
