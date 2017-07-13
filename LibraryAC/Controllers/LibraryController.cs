using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryAC.Models;
using LibraryAC.Models.LibraryViewModels;
using LibraryAC.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using LibraryAC.Data.Entities;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        public IActionResult Index()
        {
            var books = _libraryService.GetAllBooks();

            var transactions = _libraryService.GetTransactions();

            bool IsLoggedIn = HttpContext.User.Identity.IsAuthenticated;

            string currentUser=null;

            if(IsLoggedIn)
            {
                currentUser= HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            var model = new LibraryViewModel(books, transactions,currentUser);
            
            return View(model);
        }

        
        public IActionResult Borrow(int id)
        {
          
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isSuccessful = _libraryService.Borrow( id, userId);

            var book = _libraryService.GetAllBooks().Single(item => item.Id == id);

            var borrowViewModel = new BorrowViewModel
            {
                IsSuccessfull = isSuccessful,
                BookName = book.Name
            };

            return View(borrowViewModel);
        }

       
        public IActionResult Return(int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isSucessful = _libraryService.Return(id, userId);

            var returnViewModel = new ReturnViewModel()
            {
                IsSuccessful = isSucessful,
                BookName = _libraryService.GetAllBooks().Single(t => t.Id == id)?.Name
            };

            return View(returnViewModel);
        }

       
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add()
        {

            Book book = new Book()
            {
                Author = Request.Form["author"],
                Name = Request.Form["name"],
                NumberOfCopies = Int32.Parse(Request.Form["copies"])
            };

            bool success = false;

            if (book.Author != null && book.Name != null && book.NumberOfCopies != 0)
            {

                success = _libraryService.AddBook(book);
            }

            var addModel = new AddViewModel()
            {
               
                Name = book.Name,
                IsSuccessful = success
                
            };

            return View(addModel);
        }

    }
}