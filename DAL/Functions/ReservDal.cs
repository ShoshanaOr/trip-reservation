using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class ReservDal : IreservDal
    {
        OrganizedTripContext orgTrips;
        public ReservDal(OrganizedTripContext db)
        {
            orgTrips = db;
        }

        //add
        public bool AddReserv(Reservation res)
        {
            orgTrips.Reservations.Add(res);
            orgTrips.SaveChanges();
            return true;
        }

        //delete
        public bool DeleteReserv(int id)
        {
            Reservation? r = orgTrips.Reservations.FirstOrDefault(res => res.ReservationCode == id);
            if (r != null)
            {
                orgTrips.Reservations.Remove(r);
                orgTrips.SaveChanges();
                return true;
            }
            return false;
        }

        //getAll
        public List<Reservation> GetReserv()
        {
            return orgTrips.Reservations.Include(r => r.TourCodeNavigation).ToList();
        }

        //getById
        public Reservation? GetReservById(int id)
        {
            return orgTrips.Reservations.Include(r => r.TourCodeNavigation).FirstOrDefault(res => res.ReservationCode == id);
        }

        //GetByBookerName
        public List<Reservation> GetByBookerName(string bookerName)
        {
            return orgTrips.Reservations.Include(r => r.TourCodeNavigation).Where(r => r.BookerName == bookerName).ToList();
        }

        //update
        public bool UpdateReserv(int id, int places)
        {
            Reservation? res = orgTrips.Reservations.FirstOrDefault(r => r.ReservationCode == id);
            if (res != null)
            {
                res.NumberSeats = places;
                return true;
            }
            return false;
        }
    }
}
