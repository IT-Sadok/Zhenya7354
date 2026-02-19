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
        public Status Status = Status.Available;
        public Book(int isbn, string title, string author, int publicationYear)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {Isbn}, Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}, Status: {Status} \n");
        }
    }

    enum Status
    {
        Available,
        Borrowed
    }
}
