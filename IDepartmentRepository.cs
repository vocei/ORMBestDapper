using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ORMBestDapper
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        //public Product GetProduct(int id);
        //public void UpdateProduct(Product product);
        void InsertDepartment(string newDepartmentName);

    }
}
