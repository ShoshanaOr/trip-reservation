using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IreservDal
    {
        //getAll
        public List<Reservation> GetReserv();

        //getById
        public Reservation? GetReservById(int id);

        //add
        public bool AddReserv(Reservation res);

        //update
        public bool UpdateReserv(int id, int places);

        //delete
        public bool DeleteReserv(int id);

        //getByBookerName
        public List<Reservation> GetByBookerName(string bookerName);
    }
}
