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
    public class TripDal : ItripDal
    {
        OrganizedTripContext orgTrips;
        public TripDal(OrganizedTripContext db)
        {
            orgTrips = db;
        }

        //add
        public int add(Trip tr)
        {
            orgTrips.Trips.Add(tr);
            orgTrips.SaveChanges();
            return orgTrips.Trips.OrderBy(t => t.TripCode).LastOrDefault()?.TripCode ?? -1;
        }
        //delete
        public bool delete(int id)
        {
            Trip? tr = orgTrips.Trips.FirstOrDefault(t => t.TripCode == id);
            if (tr != null)
            {
                orgTrips.Trips.Remove(tr);
                orgTrips.SaveChanges();
                return true;
            }
            return false;
        }
        //getAll
        public List<Trip> getAll()
        {
            return orgTrips.Trips.Include(t => t.Reservations).ToList();
        }
        //getById
        public Trip? getById(int id)
        {
            return orgTrips.Trips.Include(t => t.Reservations).FirstOrDefault(t => t.TripCode == id);
        }
        //update
        public bool update(int id, Trip tr)
        {
            Trip? t = orgTrips.Trips.FirstOrDefault(t => t.TripCode == id);
            if (t != null)
            {
                t.Destination = tr.Destination;
                t.TripType = tr.TripType;
                t.TripDate = tr.TripDate;
                t.DepartureTime = tr.DepartureTime;
                t.TripDuration = tr.TripDuration;
                t.AvailablePlaces = tr.AvailablePlaces;
                t.Price = tr.Price;
                t.Image = tr.Image;

                orgTrips.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
