using Kirjasto.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Kirjasto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseRepository dbRepo = new DatabaseRepository(@"Data Source=" + @"(localdb)\MSSQLLocalDB" + ";Initial Catalog=Library");
            string result = dbRepo.IsDbConnectionEstablished();

            var searchresult = dbRepo.GetBookFiveYear();
            var mostBooks = dbRepo.MaxBook();
            var users = dbRepo.LoaningMembers();
            var topBooks = dbRepo.TopThreeBooks();

            for (int i = 0; i < searchresult.Count; i++)
            {
                Console.WriteLine(searchresult[i].Name);
               
            }
            foreach (var book in mostBooks)
            {
                Console.WriteLine(book.Name);
            }
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            for (int i = 0;i < 3; i++)
            {
                Console.WriteLine(topBooks[i].Name + " " + topBooks[i].ISBN+ " "+ topBooks[i].Id+" " + topBooks[i].PublicationYear);
            }
            //dbRepo.BirthdayAdder();
            Console.WriteLine(dbRepo.AverageAge());
          

        }
    }
}
