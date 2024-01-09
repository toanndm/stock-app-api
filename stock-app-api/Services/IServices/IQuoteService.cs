using stock_app_api.Models;

namespace stock_app_api.Services.IServices
{
    public interface IQuoteService
    {
        Task<List<RealTimeQuote>?> GetRealTimeQuote(int page, int limit, string sector, string industry);
    }
}
