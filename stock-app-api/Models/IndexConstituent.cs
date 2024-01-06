using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class IndexConstituent
{
    public int? IndexId { get; set; }

    public int? StockId { get; set; }

    public virtual MarketIndex? Index { get; set; }

    public virtual Stock? Stock { get; set; }
}
