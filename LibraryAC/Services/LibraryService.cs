using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAC.Data;
using LibraryAC.Data.Entities;
using LibraryAC.Models.LibraryViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryAC.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ApplicationDbContext _context;
       

        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool Borrow(int id, string userId)
        {
            int borrowedBooks = _context.Transactions.Where(t => t.UserId == userId).Count();
            
            var book = _context.Books.Single(b => b.Id == id);

            if (borrowedBooks <= 1 && book.NumberOfCopies > 0)
            {

                _context.Transactions.Add(new Transaction()
                {
                    BookId = id,
                    UserId = userId
                });

                book.NumberOfCopies--;
              
            }

            return _context.SaveChanges() == 2;
            
        }

        public IList<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public IList<Transaction> GetTransactions()
        {
            return _context.Transactions.Include(m => m.User).ToList();
        }

        public bool Return(int id, string userId)
        {
            var transaction = _context.Transactions.Single(t => t.BookId == id && t.UserId == userId);

            var book = _context.Books.Single(b => b.Id == id);

            book.NumberOfCopies++;
            
            _context.Transactions.Remove(transaction);

            return _context.SaveChanges() == 2;
        }

        public bool AddBook(Book book)
        {

            bool alreadyExists = _context.Books.Any(b => b.Name == book.Name && b.Author == book.Author);

            if (!alreadyExists)
            {
                _context.Books.Add(book);
            }

            return _context.SaveChanges() == 1;
        }
    }
}