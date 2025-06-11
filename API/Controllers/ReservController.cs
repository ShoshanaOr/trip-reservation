using BLL.DTO;
using BLL.Interf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservController : ControllerBase
    {
        IreservBll resBll;
        public ReservController(IreservBll iBll)
        {
            resBll = iBll;
        }

        //getAll
        [HttpGet]
        public ActionResult<List<ReservationDTO>> getAllReservs()
        {
            return Ok(resBll.GetAll());
        }

        //addReservToTrip
        [HttpPost]
        public ActionResult<bool> addReservToTrip(ReservationDTO res)
        {
            return Ok(resBll.Add(res));
        }

        //deleteReserv
        [HttpDelete("{id}")]
        public ActionResult<bool> deleteReserv(int id)
        {
            return Ok(resBll.Delete(id));
        }

        //getByBookerName
        [HttpGet("booker/{name}")]
        public ActionResult<List<ReservationDTO>> getByBookerName(string bookerName)
        {
            return Ok(resBll.GetByBookerName(bookerName));
        }

        //updatePlaces
        [HttpPut("{id}")]

        public ActionResult<bool> updatePlaces(int id, int places)
        {
            return Ok(resBll.UpdateReserv(id, places));
        }

        //getById
        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            return Ok(resBll.GetReservById(id));
        }

    }
}
