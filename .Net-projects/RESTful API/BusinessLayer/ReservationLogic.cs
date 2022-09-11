using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class ReservationLogic : IReservationLogic
    {
        private IDataService _ds;

        public ReservationLogic(IDataFactory dataFactory)
        {
            _ds = dataFactory.GetService();

        }

        public async Task<Reservation> AddReservation(DateTime date,int seats, string name, int tableId)
        {
            return await _ds.AddReservation(date, seats,name, tableId);

        }

        public async Task<double>  CalculTaxe(double sum, string type)
        {
            return await Helper.CalculTaxe(sum, type);
        }

        public async Task<int> CalculZileLibere(string employeeType)
        {
            return await Helper.CalculZileLibere(employeeType);
        }

        public async Task DeleteReservation(int id)
        {
            await _ds.DeleteReservation(id);
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await _ds.GetReservation(id);
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await _ds.GetReservations();
        }

        public async Task<Reservation> UpdateReservation(int id, DateTime date,int seats ,string name, int tableId)
        {
            return await _ds.UpdateReservation(id, date,seats, name, tableId);
        }
    }

}
