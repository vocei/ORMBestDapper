﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ORMBestDapper
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    }
}
