using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    class LibraryBook : Book
    {
        public LibraryBook(int isbn, string title, string author, int publicationYear)
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
        Borrowed
    }
}
