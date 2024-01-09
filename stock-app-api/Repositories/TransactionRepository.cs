using Microsoft.EntityFrameworkCore;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;

namespace stock_app_api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly StockAppContext _db;
        public TransactionRepository(StockAppContext db)
        {
            _db = db;
        }
        public async Task<List<Transaction>> GetTransactions(int userId, int page, int limit)
        {
            return await _db.Transactions.Where(t => t.UserId == userId)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }
    }
}
