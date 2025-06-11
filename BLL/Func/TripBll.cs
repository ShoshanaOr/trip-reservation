using AutoMapper;
using BLL.DTO;
using BLL.Interf;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Func
{
    public class TripBll : ItripBll
    {
        ItripDal iDal;
        IMapper im;
        public TripBll(ItripDal tdal)
        {
            iDal = tdal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Mapper>();
            });
            im = config.CreateMapper();
        }

        //add
        public int add(TripDTO trip)
        {
            TimeSpan difference = trip.TripDate - DateTime.Now;
            if (difference.TotalDays >= 5)
            {
                int newTr = iDal.add(im.Map<TripDTO, Trip>(trip));
                return newTr;
            }
            return -2;
        }

        //delete
        public bool delete(int id)
        {
            return iDal.delete(id);
        }

        //getAll
        public List<TripDTO> getAll()
        {
            List<Trip> trips = iDal.getAll();
            List<TripDTO> allTrips = im.Map<List<Trip>, List<TripDTO>>(trips);

            foreach (var trip in allTrips)
            {
                trip.ProfitToTrip = 0;
                foreach (var res in trip.ReservDetails)
                {
                    if (res.Key.AddDays(10) <= trip.TripDate)
                    {
                        trip.ProfitToTrip += 0.9m * trip.Price * res.Value;
                    }
                    else
                    {
                        trip.ProfitToTrip += trip.Price * res.Value;
                    }
                }
            }
            return allTrips;
        }

        //getById
        public TripDTO? getById(int id)
        {
            Trip? tr = iDal.getById(id);
            if (tr != null)
            {
                TripDTO trip = im.Map<Trip, TripDTO>(tr);
                foreach (var res in trip.ReservDetails)
                {
                    if (res.Key.AddDays(10) <= trip.TripDate)
                    {
                        trip.ProfitToTrip += 0.9m * trip.Price * res.Value;
                    }
                    else
                    {
                        trip.ProfitToTrip += trip.Price * res.Value;
                    }
                }
                return trip;
            }
            return null;
        }

        //update
        public bool update(int id, TripDTO trip)
        {
            TripDTO? oldTrip = getById(id);

            if (oldTrip?.TripDate > DateTime.Now && trip.TripDate > DateTime.Now)
            {
                bool upTr = iDal.update(id, im.Map<TripDTO, Trip>(trip));
                return upTr;
            }
            return false;
        }

        //GetReservsToTrip
        public List<ReservationDTO> GetReservsToTrip(int id)
        {
            TripDTO? tr = getById(id);
            if (tr != null)
            {
                return tr.ReservsList;
            }
            else throw new Exception("This trip not find");
        }
    }
}
