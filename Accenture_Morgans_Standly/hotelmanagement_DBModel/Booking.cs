using System;
using System.Collections.Generic;

namespace Accenture_Morgans_Standly.hotelmanagement_DBModel;

public partial class Booking
{
    public int? Id { get; set; }

    public string? CustomerName { get; set; }

    public string? Location { get; set; }

    public DateOnly? Date { get; set; }
}
