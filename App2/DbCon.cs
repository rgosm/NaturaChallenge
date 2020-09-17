using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App2
{
    public class DbCon
    {
        readonly SQLiteAsyncConnection _database;

        public DbCon(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WonderWoman>().Wait();
        }

        public Task<List<WonderWoman>> GetWonderWomanAsync()
        {
            return _database.Table<WonderWoman>().ToListAsync();
        }

        public Task<int> SaveWonderWomanAsync(WonderWoman woman)
        {
            return _database.InsertAsync(woman);
        }
    }
}
