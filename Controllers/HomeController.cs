using Microsoft.AspNetCore.Mvc;
using BookStore.Repository;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepository context = new BookRepository();
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet("search")]
        public ActionResult Index(string searchVal)
        {
            if(searchVal != null){
                ViewBag.IsSearch = true;
                ViewBag.searchVal = searchVal;
                var data = context.SearchBook(searchVal);
                return View(data);
            }
            return View();
        }
        public ViewResult About()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}