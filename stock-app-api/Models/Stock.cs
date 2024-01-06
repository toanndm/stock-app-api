using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public string Symbol { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public decimal? MarketCap { get; set; }

    public string? Sector { get; set; }

    public string? Industry { get; set; }

    public string? SectorEn { get; set; }

    public string? IndustryEn { get; set; }

    public string? StockType { get; set; }

    public int? Rank { get; set; }

    public string? Reason { get; set; }

    public string? RankSource { get; set; }

    public virtual ICollection<CoveredWarrant> CoveredWarrants { get; set; } = new List<CoveredWarrant>();

    public virtual ICollection<Derivative> Derivatives { get; set; } = new List<Derivative>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
