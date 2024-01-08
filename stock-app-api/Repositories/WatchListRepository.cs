using Microsoft.EntityFrameworkCore;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;

namespace stock_app_api.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly StockAppContext _db;
        public WatchListRepository(StockAppContext db)
        {
            _db = db;
        }
        public async Task<bool> AddWatchList(WatchList watchList)
        {
            try
            {
                _db.WatchLists.Add(watchList);
                await _db.SaveChangesAsync();
                return true;
            } catch (DbUpdateException ex)
            {
                throw new ArgumentException("Error updating the database.", ex);
            }
        }

        public async Task<IEnumerable<WatchList>> GetWatchListByUserId(int userId)
        {

            var watchLists = await _db.WatchLists
                .Include(w => w.User)
                .Include(w => w.Stock)
                .Where(w => w.UserId == userId).ToListAsync();
            return watchLists;
        }
    }
}
