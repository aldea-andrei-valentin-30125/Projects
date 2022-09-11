using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SQLService : IDataService
    {
        public MyDBContext _context = new MyDBContext();
        public async Task<List<Reservation>> GetReservations()
        {
            List<Reservation> reservationList = await _context.reservations.Include(b => b.Table).ToListAsync();
            return reservationList;
        }

        public async Task<Reservation> GetReservation(int id)
        {
            Reservation reservation = await _context.reservations.Where(b => b.Id == id).Include(b => b.Table).FirstOrDefaultAsync();
            return reservation ;
        }

        public async Task DeleteReservation(int id)
        {
            Reservation reservation = await _context.reservations.FindAsync(id);
            _context.reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> UpdateReservation(int id,DateTime date,int seats,string name,int tableId )
        {
            Reservation reservation = await _context.reservations.FindAsync(id);
            reservation.ReservationDate = date;
            reservation.ReservationName = name;
            Table table = await _context.tables.FindAsync(tableId);
            reservation.Table = table;
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<Reservation> AddReservation(DateTime date,int seats, string name, int tableId)
        {
            Table table = await _context.tables.FindAsync(tableId);
            table.OccupiedSeats = seats;
            Reservation reservation = new Reservation { ReservationDate = date, ReservationName = name,Seats = seats, Table = table };
            _context.reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
    }
}
