using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class Portfolio
{
    public int? UserId { get; set; }

    public int? StockId { get; set; }

    public int? Quantity { get; set; }

    public decimal? PurchasePrice { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public virtual Stock? Stock { get; set; }

    public virtual User? User { get; set; }
}
