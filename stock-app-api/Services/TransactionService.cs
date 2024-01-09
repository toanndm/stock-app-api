using stock_app_api.Repositories.IRepository;
using stock_app_api.Services.IServices;
using stock_app_api.ViewModels.DTOs;

namespace stock_app_api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<TransactionDTO>> GetTransactions(int userId, int page, int limit)
        {
            var transactions = await _transactionRepository.GetTransactions(userId, page, limit);
            IEnumerable<TransactionDTO> results = transactions.Select(transaction => new TransactionDTO
            {
                UserId = transaction.UserId,
                LinkedAccountId = transaction.LinkedAccountId,
                TransactionType = transaction.TransactionType,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate
            });
            return results;
        }
    }
}
