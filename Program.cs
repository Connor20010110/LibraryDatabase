using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Xml.Linq;

namespace LibraryDatabase2
{

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
            "server=localhost;port=3306;database=LibraryDB;user=root;password = root";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection to database successful!");
                    bool menurunning = true;

                    while (menurunning)
                    {                     
                        Console.WriteLine("\nLibrary Management System");
                        Console.WriteLine("1. Add a new book");
                        Console.WriteLine("2. Update book details");
                        Console.WriteLine("3. Delete a book");
                        Console.WriteLine("4. View all books");
                        Console.WriteLine("5. Search for a book by title");
                        Console.WriteLine("6. Exit");
                        Console.Write("Select an option: ");

                        switch (Console.ReadLine())
                        {
                            case "1":// Add a new book

                                Console.Write("Enter book title: ");
                                string title = Console.ReadLine();

                                Console.Write("Enter author: ");
                                string author = Console.ReadLine();

                                Console.Write("Enter publication year: ");
                                int publicationyear;
                                while (true)
                                {
                                    Console.Write("Enter publication year: ");
                                    try
                                    {
                                        publicationyear = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Please enter a valid year.");
                                    }
                                }

                                Console.Write("Enter genre: ");
                                string genre = Console.ReadLine();

                                Library.Program.AddBook(connection, title, author, publicationyear, genre);
                                break;

                            case "2": // Update an existing book
                                int bookid;
                                while (true)
                                {
                                    Console.Write("Enter the Book ID you wanrt to update: ");
                                    try
                                    {
                                        bookid = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid Book ID.");
                                    }
                                }

                                Console.Write("Enter new title: ");
                                string title2 = Console.ReadLine();

                                Console.Write("Enter new author: ");
                                string author2 = Console.ReadLine();

                                int publicationyear2;
                                while (true)
                                {
                                    Console.Write("Enter new publication year: ");
                                    try
                                    {
                                        publicationyear2 = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid year.");
                                    }
                                }

                                Console.Write("Enter new genre: ");
                                string genre2 = Console.ReadLine();

                                Library.Program.UpdateBook(connection, bookid, title2, author2, publicationyear2, genre2);
                                break;

                            case "3":// Delete a book

                                int bookid2;
                                while (true)
                                {
                                    Console.Write("Enter the Book ID you wanrt to delete: ");
                                    try
                                    {
                                        bookid2 = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Invalid input. Please enter a valid Book ID.");
                                    }
                                }
                                Library.Program.DeleteBook(connection, bookid2);
                                break;

                            case "4":// See all books
                                Library.Program.GetAllBooks(connection);
                                break;

                            case "5":// Search for a book
                                Console.WriteLine("Enter the books title you want to search for:");
                                string titlesearch = Console.ReadLine();
                                Library.Program.SearchBookByTitle(connection, titlesearch);
                                break;

                            case "6":
                                menurunning = false;
                                Console.WriteLine("Exiting application");
                                break;
                            default:
                                Console.WriteLine("Invalid selection. Please try again.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
