using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class EtfQuote
{
    public int QuoteId { get; set; }

    public int? EtfId { get; set; }

    public decimal Price { get; set; }

    public decimal Change { get; set; }

    public decimal PercentChange { get; set; }

    public int TotalVolume { get; set; }

    public DateTime TimeStamp { get; set; }

    public virtual Etf? Etf { get; set; }
}
