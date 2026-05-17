using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LibraryManager;


    internal abstract class Book
    {
        public int Isbn { get; set; }
         public string Title { get; set; }
         public string Author { get; set; }
         public int PublicationYear { get; set; }
         public Status Status { get; set; } = Status.Available;
    }

