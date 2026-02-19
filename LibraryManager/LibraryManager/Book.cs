using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    class Book
    {
        public int Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        Status status = Status.Available;
        public Book(int isbn, string title, string author, int publicationYear)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
    }

    enum Status
    {
        Available,
        Leased
    }
}
