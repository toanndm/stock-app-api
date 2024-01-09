using stock_app_api.Models;

namespace stock_app_api.ViewModels
{
    public class OrderViewModel
    {
        public int? StockId { get; set; }

        public string? OrderType { get; set; }

        public string? Direction { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string? Status { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
