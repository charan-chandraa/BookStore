using System.Collections.Generic;
using BookStore.Models;
using System.Linq;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="The Alchemist", Author="Paulo Coelho", Description="This is the description for The Alchemist book."},
                new BookModel(){Id=2, Title="The legend of suheldev", Author="Amish Tripati", Description="This is the description for The legend of suheldev book."},
                new BookModel(){Id=3, Title="Shiva Trilogy", Author="Amish Tripati", Description="This is the description for Shiva Triology book."},
                new BookModel(){Id=4, Title="The lost Symbol", Author="Dan Brown", Description="This is the description for The lost symbol book."},
                new BookModel(){Id=5, Title="Stranger Trilogy", Author="Navoneel Chakrabothy", Description="This is the description for Stranger Trilogy book."}
            };
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id ==id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }
    }
}