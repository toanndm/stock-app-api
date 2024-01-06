using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class Quote
{
    public int QuoteId { get; set; }

    public int? StockId { get; set; }

    public decimal Price { get; set; }

    public decimal Change { get; set; }

    public decimal PercentChange { get; set; }

    public int Volume { get; set; }

    public DateTime TimeStamp { get; set; }

    public virtual Stock? Stock { get; set; }
}
