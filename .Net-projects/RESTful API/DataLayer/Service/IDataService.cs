using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataService
    {
        public Task<Reservation> GetReservation(int id);

        public Task DeleteReservation(int id);
        public Task<Reservation> UpdateReservation(int id, DateTime date,int seats, string name, int tableId);

        public Task<Reservation> AddReservation(DateTime date,int seats, string name, int tableId);

        public Task<List<Reservation>> GetReservations();

    }
}
