using stock_app_api.Models;

namespace stock_app_api.Repositories.IRepository
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactions(int userId, int page, int limit);
    }
}
