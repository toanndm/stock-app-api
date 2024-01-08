using stock_app_api.Models;

namespace stock_app_api.Repositories.IRepository
{
    public interface IWatchListRepository
    {
        Task<IEnumerable<WatchList>> GetWatchListByUserId(int userId);
        Task<Boolean> AddWatchList(WatchList watchList);
    }
}
