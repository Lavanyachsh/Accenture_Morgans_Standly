using System;
using System.Collections.Generic;

namespace Accenture_Morgans_Standly.hotelmanagement_DBModel;

public partial class NewBooking
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? CustomerName { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }
}
