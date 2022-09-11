using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer
{
    public class Employee
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public string Name { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
