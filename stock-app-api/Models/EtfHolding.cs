using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class EtfHolding
{
    public int? EtfId { get; set; }

    public int? StockId { get; set; }

    public decimal? SharesHeld { get; set; }

    public decimal? Weight { get; set; }

    public virtual Etf? Etf { get; set; }

    public virtual Stock? Stock { get; set; }
}
