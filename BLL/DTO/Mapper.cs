using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Reservation, ReservationDTO>().ForMember(
                newR => newR.TripDestination,
                oldR => oldR.MapFrom(r => r.TourCodeNavigation.Destination)
                ).ForMember(
                newR => newR.TripDate,
                dbR => dbR.MapFrom(r => r.TourCodeNavigation.TripDate)
                );
            CreateMap<ReservationDTO, Reservation>();
            CreateMap<Trip, TripDTO>().ForMember(
                newProp => newProp.BookersNumber,
                oldProp => oldProp.MapFrom(p => p.Reservations.Count())
                ).ForMember(
                newP =>newP.ReservDetails,
                dbP => dbP.MapFrom(t => t.Reservations.ToDictionary(
                    r => r.ReservationDate, r => r.NumberSeats))
                ).ForMember(
                newP => newP.ReservsList,
                dbP => dbP.MapFrom(t => t.Reservations)
                );
               
            CreateMap<TripDTO, Trip>();           
        }
    }
}
