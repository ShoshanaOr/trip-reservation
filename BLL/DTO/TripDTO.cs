using DAL.Models;
using System;
using System.Collections.Generic;

namespace BLL.DTO;

public partial class TripDTO
{
    public int TripCode { get; set; }

    public string Destination { get; set; } = null!;

    public string TripType { get; set; } = null!;

    public DateTime TripDate { get; set; }

    public TimeSpan DepartureTime { get; set; }

    public int TripDuration { get; set; }

    public int AvailablePlaces { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int BookersNumber { get; set; }

    public decimal ProfitToTrip { get; set; }

    public Dictionary<DateTime, int> ReservDetails { get; set; } = new Dictionary<DateTime, int>();

    public List<ReservationDTO> ReservsList { get; set; }  = new List<ReservationDTO>();
}
