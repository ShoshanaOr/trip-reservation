using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Trip
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

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
