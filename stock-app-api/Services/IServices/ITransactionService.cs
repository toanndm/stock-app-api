using stock_app_api.ViewModels.DTOs;

namespace stock_app_api.Services.IServices
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDTO>> GetTransactions(int userId, int page, int limit);
    }
}
