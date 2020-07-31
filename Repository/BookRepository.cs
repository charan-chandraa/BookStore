using System.Collections.Generic;
using BookStore.Models;
using System.Linq;
using MySqlConnector;
using System;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private string connectionString = "Server=localhost;User ID=root;Password=rootPass@9699;Database=bookstore";
        public List<BookModel> GetAllBooks()
        {
            List<BookModel> list = new List<BookModel>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM books;", connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new BookModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public BookModel GetBookById(int id)
        {
            BookModel book = new BookModel();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM books WHERE Id = " + id + ";", connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        book.Id = Convert.ToInt32(reader["Id"]);
                        book.Title = reader["Title"].ToString();
                        book.Author = reader["Author"].ToString();
                        book.Description = reader["Description"].ToString();
                    }
                }
            }

            return book;
        }

        public List<BookModel> SearchBook(string searchVal)
        {
            List<BookModel> list = new List<BookModel>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM books WHERE Title LIKE '%" + searchVal + "%' || Author LIKE '%" + searchVal + "%';", connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new BookModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public int AddNewBook(BookModel book)
        {
            int bookId=0;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("INSERT INTO books (Title, Author, Description) VALUES('" + book.Title + "','" + book.Author + "','" + book.Description + "');SELECT LAST_INSERT_ID()", connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        bookId = Convert.ToInt32(reader["LAST_INSERT_ID()"]);
                    }
                }
            }
            return bookId;
        }
    }
}