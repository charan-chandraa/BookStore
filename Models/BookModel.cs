using BookStore.Repository;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter the Title of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage="Please enter the Author name")]
        public string Author { get; set; }
        public string Description { get; set; }
    }
}