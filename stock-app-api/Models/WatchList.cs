using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class WatchList
{
    public int? UserId { get; set; }

    public int? StockId { get; set; }

    public virtual Stock? Stock { get; set; }

    public virtual User? User { get; set; }
}
