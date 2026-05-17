using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager;

    interface IFileManager
    {
       public void SaveToFile(IEnumerable<Book> books);
        public List<Book> LoadFromFile();
    }

