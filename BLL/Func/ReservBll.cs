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
    public class ReservBll : IreservBll
    {
        IreservDal resDal;
        ItripBll trBll;
        IMapper im;

        public ReservBll(IreservDal iDal, ItripBll tripB)
        {
            resDal = iDal;
            trBll = tripB;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.Mapper>();
            });
            im = config.CreateMapper();
        }

        //add
        public bool Add(ReservationDTO res)
        {
            Reservation? reser = resDal.GetReservById(res.ReservationCode);
            if (reser == null)
            {
                try
                {
                    TripDTO? currentTrip = trBll.getById(res.TourCode);
                    res.ReservationDate = DateTime.Now;
                    if (res.TripDate > DateTime.Now.AddDays(1))
                    {
                        if (res.NumberSeats > 0 && res.NumberSeats <= currentTrip?.AvailablePlaces)
                        {
                            bool reservAdded = resDal.AddReserv(im.Map<ReservationDTO, Reservation>(res));

                            if (reservAdded)
                            {
                                int places = currentTrip.AvailablePlaces - res.NumberSeats;
                                currentTrip.AvailablePlaces = places;
                                bool updatePlaces = trBll.update(res.TourCode, currentTrip);
                                return true;
                            }                          
                        }
                        else throw new Exception($"only {currentTrip?.AvailablePlaces} places are available.");
                    }
                    else throw new Exception("Registration for the trip is closed");
                }
                catch (Exception ex)
                {
                    throw new Exception("The data not matching to reservation trip" + ex.Message);
                }
            }       
            return false;
        }

        //delete
        public bool Delete(int id)
        {
            ReservationDTO? res = GetReservById(id);
            if (res?.TripDate > DateTime.Now )
            {
                bool reservDeleted = resDal.DeleteReserv(id);
                if (reservDeleted)
                {
                    TripDTO? currentTr = trBll.getById(res.TourCode);
                    currentTr.AvailablePlaces += res.NumberSeats;
                    return true; 
                }
                else return false;
            }
            else throw new Exception("The trip has already passed");
        }

        //getAll
        public List<ReservationDTO> GetAll()
        {
            return im.Map<List<Reservation>, List<ReservationDTO>>(resDal.GetReserv());
        }

        //GetByBookerName
        public List<ReservationDTO> GetByBookerName(string bookerName)
        {
            return im.Map<List<Reservation>, List<ReservationDTO>>(resDal.GetByBookerName(bookerName));
        }

        //getById
        public ReservationDTO? GetReservById(int id)
        {
            ReservationDTO? res = im.Map<Reservation, ReservationDTO>(resDal.GetReservById(id));
            return res;
        }

        //update
        public bool UpdateReserv(int id, int places)
        {
            return resDal.UpdateReserv(id, places);
        }
    }
}
