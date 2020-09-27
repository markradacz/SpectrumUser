using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpectrumApp
{
    public interface IDataStore<T>
    {
        Task<int> AddUpdateUserAsync(T item);
        Task<int> DeleteUserAsync(T item);
        Task<int> DeleteUserAsync(int id);
        Task<T> FindUserAsync(string username);
        Task<T> GetUserAsync(int id);
        Task<List<T>> GetUsersAsync();
    }
}
