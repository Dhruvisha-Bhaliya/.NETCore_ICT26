using System;
using System.Collections.Generic;

namespace Assignment_3_2.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? Color { get; set; }

    public decimal? Price { get; set; }
}
