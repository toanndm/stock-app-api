namespace stock_app_api.ViewModels.DTOs
{
    public class TransactionDTO
    {
        public int? UserId { get; set; }

        public int? LinkedAccountId { get; set; }

        public string? TransactionType { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? TransactionDate { get; set; }
    }
}
