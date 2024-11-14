using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase2
{
    public class Library
    {
        public class Program
        {
            public static void AddBook(MySqlConnection connection, string title, string author, int publicationyear, string genre)
            {
                string query = "INSERT INTO Books (Title, Author, PublicationYear, Genre) VALUES(@Title, @Author, @PublicationYear, @Genre)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@PublicationYear", publicationyear);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        Console.WriteLine("Book added successfully.");
                    else
                        Console.WriteLine("Failed to add book.");
                }
            }

            public static void GetAllBooks(MySqlConnection connection)
            {
                string query = "SELECT * FROM Books";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"BookID: {reader["BookID"]}, Title:{reader["Title"]}, Author: {reader["Author"]}, PublicationYear:{reader["PublicationYear"]}, Genre: {reader["Genre"]}");
                        }
                    }
                }
            }

            public static void UpdateBook(MySqlConnection connection, int bookid, string title, string author, int publicationyear, string genre)
            {
                string query = "UPDATE Books SET Title = @Title, Author = @Author, PublicationYear = @PublicationYear, Genre = @Genre WHERE BookID = @BookID";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", bookid);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@PublicationYear", publicationyear);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        Console.WriteLine("Book updated successfully.");
                    else
                        Console.WriteLine("Failed to update Book.");
                }
            }
            public static void DeleteBook(MySqlConnection connection, int bookid)
            {
                string query = "DELETE FROM Books WHERE BookID = @BookID";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", bookid);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        Console.WriteLine("Book deleted successfully.");
                    else
                        Console.WriteLine("Failed to delete Book.");
                }
            }

            public static void SearchBookByTitle(MySqlConnection connection, string title)
            {
                string query = "SELECT * FROM books WHERE title = @Title";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", title);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"BookID: {reader["BookID"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, PublicationYear: {reader["PublicationYear"]}, Genre: {reader["Genre"]}");
                        }
                    }
                }
            }
        }
    }
}
