using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager;

    interface IFileManager
    {
       public void SaveToFile(IEnumerable<LibraryBook> books);
        public List<LibraryBook> LoadFromFile();
    }

