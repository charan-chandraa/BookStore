using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}", Name="bookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            var book =  _bookRepository.GetBookById(id);
            return View(book);
        }
        public ViewResult SearchBook(string title, string author)
        {
            var data = _bookRepository.SearchBook(title, author);
            return View();
        }
        public ViewResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddNewBook(BookModel bookModel)
        {   
            return View();
        }
    }
}