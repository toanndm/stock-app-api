using stock_app_api.Models;

namespace stock_app_api.Repositories.IRepository
{
    public interface IQuoteRepository
    {
        Task<List<RealTimeQuote>?> GetRealtimeQuote(int page, int limit, string sector, string industry);
    }
}
