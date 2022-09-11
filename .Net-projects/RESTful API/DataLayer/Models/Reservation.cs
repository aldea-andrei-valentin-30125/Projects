using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ReservationName { get; set; }
        public int Seats { get; set; }
        public DateTime ReservationDate { get; set; }
        public Table Table { get; set; }

    }
}
