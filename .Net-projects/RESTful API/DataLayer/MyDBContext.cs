//using Microsoft.EntityFrameworkCore.SqlServer;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MyDBContext : DbContext
    {
        public DbSet<Table> tables { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Employee> employees { get; set; }

        public MyDBContext()
             : base("Data Source=DESKTOP-VMVAKM3;Initial Catalog=internship;Integrated Security=True")
        {

        }
    }
}
