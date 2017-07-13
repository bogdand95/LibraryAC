using System.Collections.Generic;
using LibraryAC.Data.Entities;
using System.Linq;

namespace LibraryAC.Models.LibraryViewModels
{
    public class LibraryViewModel
    {
        public IList<BookModel> Books { get; set; }

        public int borrowedBooks;
        public LibraryViewModel(IList<Book> books,IList<Transaction> transaction,string currentUser)
        {
            Books = new List<BookModel>();

            borrowedBooks = transaction.Where(t => t.UserId == currentUser).Count();
          


            foreach (var book in books)
            {
           

                Books.Add(new BookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    NumberOfCopies = book.NumberOfCopies,
                    IsBorrowed = transaction.Any(t => t.BookId == book.Id),
                    IsBorrowedByMe=transaction.Any(t =>t.UserId == currentUser && t.BookId == book.Id)
                });
            }
        }
    }
}