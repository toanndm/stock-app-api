using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class CoveredWarrant
{
    public int WarrantId { get; set; }

    public string Name { get; set; } = null!;

    public int? StockId { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? Expiration { get; set; }

    public decimal? StrikePrice { get; set; }

    public string? WarrantType { get; set; }

    public virtual Stock? Stock { get; set; }
}
