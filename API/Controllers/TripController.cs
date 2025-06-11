using BLL.DTO;
using BLL.Interf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        ItripBll iBll;
        public TripController(ItripBll tr)
        {
            iBll = tr;
        }

        //getAllTrips
        [HttpGet]
        public ActionResult<List<TripDTO>> getAllTrips()
        {
            return Ok(iBll.getAll());
        }

        //getTripById
        [HttpGet("{id}")]
        public ActionResult<TripDTO> getTripById(int id)
        {
            return Ok(iBll.getById(id));
        }

        //addTrip
        [HttpPost]
        public ActionResult<int> addTrip(TripDTO trip)
        {
            return Ok(iBll.add(trip));
        }

        //updateTrip
        [HttpPut("{id}")]
        public ActionResult<bool> updateTrip(int id, TripDTO trip)
        {
            return Ok(iBll.update(id, trip));
        }

        //deleteTrip
        [HttpDelete]
        public ActionResult<bool> deleteTrip(int id)
        {
            return Ok(iBll.delete(id));
        }

        //getReservsToTrip
        [HttpGet("resToTrip/{id}")]
        public ActionResult<List<ReservationDTO>> getReservsToTrip(int id)
        {
            return Ok(iBll.GetReservsToTrip(id));
        }
    }
}
