using Currency.Mobile.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Currency.Mobile.Services
{
    public class CurrencyService
    {
        public async Task<IEnumerable<CurrencyEntity>> GetCurrenciesAsync()
        {
            HttpClient client = new HttpClient();

            var url = "https://www.nbrb.by/api/exrates/rates?periodicity=0&amp";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<IEnumerable<CurrencyEntity>>(content);

                return result;
            }
            return null;
        }
    }
}
