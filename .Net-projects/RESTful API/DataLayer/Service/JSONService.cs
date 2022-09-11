using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataLayer
{
    public class JSONService : IDataService
    {
        public MyDBContext _context = new MyDBContext();

        public  async Task<Reservation> AddReservation(DateTime date, int seats, string name, int tableId)
        {   
            Reservation reservation = new Reservation { Id = _context.reservations.LastOrDefault().Id + 1, ReservationDate = date, ReservationName = name, Seats = seats,Table = _context.tables.Find(tableId) };
            string json = JsonSerializer.Serialize(reservation);
            File.WriteAllText("reservation.json", json);
            return reservation;
            
        }

        public async Task DeleteReservation(int id)
        {
            StreamReader r = new StreamReader("reservation.json");
            string json = r.ReadToEnd();
            List<Reservation> items = JsonSerializer.Deserialize<List<Reservation>>(json);
            foreach (Reservation item in items)
            {
                if (item.Id == id)
                {
                    items.Remove(item);
                    break;
                }
            }
            File.WriteAllText("reservation.json", JsonSerializer.Serialize(items));
            throw new NotImplementedException();

        }

        public async Task<Reservation> GetReservation(int id)
        {

            StreamReader r = new StreamReader("reservation.json");
            string json = r.ReadToEnd();
            List<Reservation> items = JsonSerializer.Deserialize<List<Reservation>>(json);
            Reservation itemToReturn = new Reservation();
            foreach(Reservation item in items)
            {
                if(item.Id == id)
                {
                    itemToReturn = item;
                    break;
                }
            }
            return itemToReturn;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            /*List<Reservation> populateJson = _context.reservations.Include(b => b.Table).ToList();
            File.WriteAllText("reservation.json", JsonSerializer.Serialize(populateJson));*/


            StreamReader r = new StreamReader("reservation.json");
            string json = r.ReadToEnd();
            List<Reservation> items = JsonSerializer.Deserialize<List<Reservation>>(json);
            return items;
        }


        public async Task<Reservation> UpdateReservation(int id, DateTime date,int seats, string name, int tableId)
        {
            StreamReader r = new StreamReader("reservation.json");
            string json = r.ReadToEnd();
            List<Reservation> items = JsonSerializer.Deserialize<List<Reservation>>(json);
            Reservation itemToReturn = new Reservation();
            foreach (Reservation item in items)
            {
                if (item.Id == id)
                {
                    item.ReservationDate = date;
                    item.ReservationName = name;
                    item.Table = _context.tables.Find(tableId);
                    item.Seats = seats;
                    itemToReturn = item;
                    break;
                }
            }
            ;
            File.WriteAllText("reservation.json", JsonSerializer.Serialize(items));
            return itemToReturn;
        }
    }
}
