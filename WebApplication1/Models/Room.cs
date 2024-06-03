﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? RoomName { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
