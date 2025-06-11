using System;
using System.Collections.Generic;

namespace BLL.DTO;

public partial class ReservationDTO
{
    public int ReservationCode { get; set; }

    public string BookerName { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public DateTime ReservationDate { get; set; }

    public int TourCode { get; set; }

    public int NumberSeats { get; set; }

    public string TripDestination { get; set; } = null!;

    public DateTime TripDate { get; set; }

}
