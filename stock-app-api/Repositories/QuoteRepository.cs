using Microsoft.EntityFrameworkCore;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;

namespace stock_app_api.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly StockAppContext _db;
        public QuoteRepository(StockAppContext db)
        {
            _db = db;
        }
        public async Task<List<RealTimeQuote>?> GetRealtimeQuote(int page, int limit, string sector, string industry)
        {
            var query = _db.RealTimeQuotes
                .Skip((page - 1) * limit)
                .Take(limit);
            if (!string.IsNullOrEmpty(sector) )
            {
                query = query.Where(q => (q.SectorEn??"").ToLower().Equals(sector.ToLower()));
            }
            if (!string.IsNullOrEmpty(industry) )
            {
                query = query.Where(q => (q.IndustryEn??"").ToLower().Equals(industry.ToLower()));
            }
            var quotes = await query.ToListAsync();
            return quotes; 
        }
    }
}
