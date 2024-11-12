using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace Kirjasto.Models
{
    public class DatabaseRepository
    {
        private string _connectionString;

        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string IsDbConnectionEstablished()
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                return "Connection established!";
            }
            catch (SqlException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Book> GetBookFiveYear()
        {
            List<Book> books = new();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var year = DateTime.Now.Year;
            int pastYears = year - 5;
            using var command = new SqlCommand("SELECT * FROM Book WHERE PublicationYear BETWEEN "+ pastYears+" AND "+ year, connection);
            using var reader = command.ExecuteReader(); 
            while (reader.Read())
            {
                Book book = new()
                {
                    Id = Convert.ToInt32(reader["BookId"]),
                    Name = reader["Title"].ToString()
                };
                books.Add(book);
            }
            return books;
        }
        public void BirthdayAdder()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            Random random = new Random();
            for (int i = 0; i < 13; i++)
            {
                int randomBirthyear = random.Next(1930 , 2023);
                using var command = new SqlCommand("UPDATE Member SET BirthYear = " + randomBirthyear + "Where MemberId ="+i+";", connection);
                command.ExecuteNonQuery();
            }
        }
        public string AverageAge()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT AVG(BirthYear) AS AvgBirthYear FROM Member", connection);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var avgBirthYear = Convert.ToInt32(reader["AvgBirthYear"]);
                return avgBirthYear.ToString();
            }
            else { return "Average age not gotten"; }
        }
        public List<Book> MaxBook()
        {
            using var connection = new SqlConnection(_connectionString);
            List<Book> books = new();
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Book  WHERE AvailableCopies = (SELECT MAX(AvailableCopies) FROM Book)", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new()
                {
                    Id = Convert.ToInt32(reader["BookId"]),
                    Name = reader["Title"].ToString()
                };
                books.Add(book);
            }
            return books;
        }
        public string[] LoaningMembers()
        {
            List<User> users = new List<User>();
            List<Book> books1 = new List<Book>();
            using var connection = new SqlConnection(_connectionString);
            List<Book> books = new();
            connection.Open();
            using var command = new SqlCommand("SELECT m.FirstName,m.LastName, b.ISBN, b.Title FROM Member m INNER JOIN Loan l ON m.MemberId = l.MemberId INNER JOIN Book b ON l.BookId=b.BookId;",connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new()
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                Book book = new()
                {
                    Name = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString()
                };

                users.Add(user);
                books1.Add(book);
            }
            string[] peopleAndBooks= new string[users.Count];
            for (int i = 0;i<users.Count;i++)
            {
                peopleAndBooks[i] = (users[i].FirstName + " " + users[i].LastName) + " Book ISBN "+ books1[i].ISBN;
            }
            return peopleAndBooks;
        }
        public List<Book> TopThreeBooks()
        {
            List<Book> books = new();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT b.BookId,b.Title,b.ISBN ,b.PublicationYear , COUNT(l.BookId) AS LoanTimes FROM Book b INNER JOIN Loan l ON b.BookId=l.BookId  INNER JOIN Member m ON l.MemberId=m.MemberId  GROUP BY b.BookId,b.Title,b.ISBN,b.PublicationYear  ORDER BY COUNT(l.BookId) DESC;", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new()
                {
                    Name = reader["Title"].ToString(),
                    Id = Convert.ToInt32(reader["BookId"]),
                    ISBN = reader["ISBN"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"])
                };
            books.Add(book);
            }
            return books;
        }
    }
}

