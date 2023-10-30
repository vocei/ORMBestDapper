using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace ORMBestDapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {

            return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
        }
        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
             new { departmentName = newDepartmentName });
        }

        // Bonus Attempted Reached Exception "MySqlException: Parameter '@productID' must be defined."


        //public Product GetProduct(int id)
        //{
        //    return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;", new { id = id }); 
        //}

        //public void UpdateProduct(Product product)
        //{
        //    _connection.Execute("UPDATE products" +
        //        " SET Name = @name," +
        //        " Price = @price, " +
        //        " CategoryID = @catID," +
        //        " OnSale = @onSale," +
        //        " StockLevel = @stock;" +
        //        " WHERE ProductID = @productID;",
        //        new {
        //            name = product.Name, 
        //            price = product.Price, 
        //            catID = product.CategoryID, 
        //            onSale = product.OnSale,
        //            stock = product.StockLevel

        //        });
    }
}
