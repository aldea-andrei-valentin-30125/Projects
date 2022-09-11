using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Table
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public Employee Employee { get; set; }
        public int Seats { get; set; }
        public int OccupiedSeats { get; set; }

    }
}
