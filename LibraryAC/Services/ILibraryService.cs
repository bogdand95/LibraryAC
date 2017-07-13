using System.Collections.Generic;
using LibraryAC.Data.Entities;
using LibraryAC.Models.LibraryViewModels;

namespace LibraryAC.Services
{
    public interface ILibraryService
    {
        IList<Book> GetAllBooks();

        IList<Transaction> GetTransactions();
        bool Borrow(int id, string userId);
        bool Return(int id, string userId);
        bool AddBook(Book book);
    }
}
