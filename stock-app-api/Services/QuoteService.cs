using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using stock_app_api.Services.IServices;

namespace stock_app_api.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
        public async Task<List<RealTimeQuote>?> GetRealTimeQuote(int page, int limit, string sector, string industry)
        {
            return await _quoteRepository.GetRealtimeQuote(page, limit, sector, industry);
        }
    }
}
