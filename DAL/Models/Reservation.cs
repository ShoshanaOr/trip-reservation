using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Reservation
{
    public int ReservationCode { get; set; }

    public string BookerName { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public DateTime ReservationDate { get; set; }

    public int TourCode { get; set; }

    public int NumberSeats { get; set; }

    public virtual Trip TourCodeNavigation { get; set; } = null!;
}
