using System.Collections.Generic;
using System.Threading.Tasks;

namespace Currency.Mobile.Services
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
