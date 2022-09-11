using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IReservationLogic _reservationLogic;

        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        public RestaurantController(IReservationLogic reseravationLogic)
        {
            _reservationLogic = reseravationLogic;
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public async Task<string> Get()
        {
            return JsonSerializer.Serialize(await _reservationLogic.GetReservations(), options);
        }

        [HttpGet("ZileLibere")]

        public async Task<int> ZileLibere(string type)
        {
            return await _reservationLogic.CalculZileLibere(type);
        }

        [HttpGet("CalculTaxe")]
        public async Task<double> CalculTaxe(double sum, string type)
        {
            return await _reservationLogic.CalculTaxe(sum, type);
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return JsonSerializer.Serialize(await _reservationLogic.GetReservation(id), options);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public async Task<string> Post(DateTime data,int seats,string name,int tableId)
        {
            return JsonSerializer.Serialize(await _reservationLogic.AddReservation(data,seats,name,tableId), options);
        }
    

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, DateTime data,int seats, string name, int tableId)
        {
        return JsonSerializer.Serialize(await _reservationLogic.UpdateReservation(id,data,seats, name, tableId), options);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _reservationLogic.DeleteReservation(id);
        }
    }
}
