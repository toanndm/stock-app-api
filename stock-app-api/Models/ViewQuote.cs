using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class ViewQuote
{
    public int QuoteId { get; set; }

    public string Symbol { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string IndexName { get; set; } = null!;

    public string IndexSymbol { get; set; } = null!;

    public decimal? MarketCap { get; set; }

    public string? SectorEn { get; set; }

    public string? IndustryEn { get; set; }

    public string? StockType { get; set; }

    public decimal Price { get; set; }

    public decimal PercentChange { get; set; }

    public int Volume { get; set; }

    public DateTime TimeStamp { get; set; }
}
