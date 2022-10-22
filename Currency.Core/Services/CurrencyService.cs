using Currency.Core.Configurations;
using Currency.Core.Interfaces;
using Currency.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async ValueTask<IEnumerable<CurrencyEntity>> GetAllAsync()
        {
            using HttpClient client = new();

            var response = await client.GetAsync(AppSettings.PATH);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<CurrencyEntity>>(content);
            }

            return null;
        }
    }
}
