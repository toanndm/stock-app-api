using Microsoft.EntityFrameworkCore;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using System.Collections.Generic;

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

        public async Task<IEnumerable<WatchList>> GetWatchListByUserId(int userId, int page, int limit)
        {

            var watchLists = await _db.WatchLists.Where(w => w.UserId == userId)
            .Skip((page - 1) * limit)
            .Take(limit).ToListAsync();
            return watchLists;
        }
    }
}
