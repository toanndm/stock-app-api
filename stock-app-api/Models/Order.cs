using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? StockId { get; set; }

    public string? OrderType { get; set; }

    public string? Direction { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual Stock? Stock { get; set; }

    public virtual User? User { get; set; }
}
