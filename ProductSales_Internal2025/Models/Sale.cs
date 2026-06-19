using System;
using System.Collections.Generic;

namespace ProductSales_Internal2025.Models;

public partial class Sale
{
    public int SalesId { get; set; }

    public int ProductId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal Discount { get; set; }

    public decimal BasePrice { get; set; }

    public decimal SalePrice { get; set; }

    public decimal Gst { get; set; }

    public decimal Totalamount { get; set; }

    public virtual Product Product { get; set; } = null!;
}
