using System;
using System.Collections.Generic;
using System.Text;

namespace TestingProject.Entities
{
    class EntEmployees
    {
        public string status { get; set; }
        public List<EntEmployeesData> data = new List<EntEmployeesData>();
        public string message { get; set; }
    }
}
