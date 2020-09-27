using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpectrumApp.Helpers;
using SQLite;

namespace SpectrumApp
{
    public class SpectrumDb : IDataStore<User>
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(AppConstants.DatabasePath, AppConstants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public SpectrumDb()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<User>> GetUsersAsync()
        {
            return Database.Table<User>().ToListAsync();
        }

        public Task<int> AddUpdateUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return Database.UpdateAsync(user);
            }
            else
            {
                return Database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return Database.DeleteAsync(user);
        }

        public Task<int> DeleteUserAsync(int id)
        {
            return Database.DeleteAsync<User>(id);
        }

        public Task<User> GetUserAsync(int id)
        {
            return Database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<User> FindUserAsync(string username)
        {
            return Database.Table<User>().Where(i => i.Username == username).FirstOrDefaultAsync();
        }

    }
}

