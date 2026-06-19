using System;
using System.Collections.Generic;

namespace MVC_Registration.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int? UserId { get; set; }

    public int? UnitsConsumed { get; set; }

    public decimal? Billamount { get; set; }

    public decimal? Surcharge { get; set; }

    public decimal? FinalBill { get; set; }

    public virtual User? User { get; set; }
}
