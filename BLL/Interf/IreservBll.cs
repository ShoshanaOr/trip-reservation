using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interf
{
    public interface IreservBll
    {
        //getAll
        public List<ReservationDTO> GetAll();

        //getById
        public ReservationDTO? GetReservById(int id);

        //add
        public bool Add(ReservationDTO res);

        //update
        public bool UpdateReserv(int id, int places);

        //delete
        public bool Delete(int id);

        //getByBookerName
        public List<ReservationDTO> GetByBookerName(string bookerName);
    }
}
