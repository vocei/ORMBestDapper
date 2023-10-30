using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Drawing.Printing;

namespace ORMBestDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration

            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion





            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

            //var productToUpdate = repo.GetProduct(940);
            //productToUpdate.Name = "Updated";
            //productToUpdate.Price = 12;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.StockLevel = 1000;
            //productToUpdate.OnSale = false;
            //repo.UpdateProduct(productToUpdate);




            Console.WriteLine("Hey, here are the current departments:");
            Console.WriteLine("Press enter to continue . . .");
            Console.ReadLine();
           
            var depos = repo.GetAllDepartments();
            Print(depos);


            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new Department?");
                userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }
            Console.WriteLine("Have a great day.");
        }

        private static void Print(IEnumerable<Department> depos)
        {

            foreach (var depo in depos)

            {
                {
                    Console.WriteLine($"ID:{depo.DepartmentID} Name:{depo.Name}");
                }
            }

        }
    }
}
 