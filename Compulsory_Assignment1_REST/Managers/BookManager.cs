using Compulsory_Assignment1_Model_Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compulsory_Assignment1_REST.Managers
{
    public class BookManager
    {
        private static readonly List<Book> Data = new List<Book>()
        {
            new Book(){Author = "Chad", ISBN13 = "1980382198687", PageNr = 200, Title="English 101"},
            new Book(){Author = "Arnold", ISBN13 = "1980382198687", PageNr = 200, Title="Hasta la vista"}
        };

        public List<Book> GetAll(string s)
        {
            List<Book> results = new List<Book>(Data);
            if (s!=null)
            {
                results = results.FindAll(book => book.Title.Contains(s, StringComparison.OrdinalIgnoreCase));
            }

            return results;
        }

        public Book GetByIMBD(string ISBN)
        {
            return Data.Find(book => book.ISBN13 == ISBN);
        }

        public Book Add(Book b1)
        {
            Data.Add(b1);
            return b1;
        }

        public Book Delete(string ISBN)
        {
            Book b1 = Data.Find(b1 => b1.ISBN13 == ISBN);
            if (b1 == null) return null;
            Data.Remove(b1);
            return b1;
        }

        public Book Update(string ISBN, Book update)
        {
            Book b = Data.Find(b1 => b1.ISBN13 == ISBN);
            if (b == null) return null;
            b.Author = update.Author;
            b.Title = update.Title;
            return b;
        }
    }
}
