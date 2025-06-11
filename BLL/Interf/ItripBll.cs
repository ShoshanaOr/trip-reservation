using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interf
{
    public interface ItripBll
    {
        //getAll
        public List<TripDTO> getAll();

        //getById
        public TripDTO? getById(int id);

        //add
        public int add(TripDTO trip);

        //update
        public bool update(int id, TripDTO trip);

        //delete
        public bool delete(int id);

        //GetReservationsToTrip
        public List<ReservationDTO> GetReservsToTrip(int id);

    }
}
