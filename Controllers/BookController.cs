using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;
using BookStore.Models;
using MySqlConnector;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository context = new BookRepository();
        public ViewResult GetAllBooks()
        {
            var data = context.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}", Name="bookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            var book = context.GetBookById(id);
            return View(book);
        }
        public ViewResult SearchBook(string searchVal)
        {
            var data = context.SearchBook(searchVal);
            return View(data);
        }
        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBook(BookModel bookModel)
        {   
            if(ModelState.IsValid)
            {
                var Id = context.AddNewBook(bookModel);
                if(Id >0)
                {
                    return RedirectToAction("AddNewBook", new{isSuccess = true, bookId = Id });
                }
            }
            return View();
        }
    }
}