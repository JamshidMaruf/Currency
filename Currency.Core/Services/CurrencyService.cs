using Currency.Core.Configurations;
using Currency.Core.DbContexts;
using Currency.Core.Interfaces;
using Currency.Core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Currency.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly AppDbContext appDbContext;
        public CurrencyService()
        {
            this.appDbContext = new AppDbContext();
        }

        public async ValueTask AddAsync()
        {
            var currencies = await GetAllAsync();
            var currenciesFromDatabese = await GetAllFromDataBaseAsync();

            foreach (var currency in currencies)
            {
                foreach (var currencyFromDatabese in currenciesFromDatabese)
                {
                    if (currency != currencyFromDatabese)
                        this.appDbContext.Add(currency);
                    await this.appDbContext.SaveChangesAsync();
                }
            }
        }

        public async ValueTask<IEnumerable<CurrencyEntity>> GetAllAsync()
        {
            using HttpClient client = new();

            var response = await client.GetAsync(AppSettings.PATH);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<IEnumerable<CurrencyEntity>>(content);

                return result;
            }
            return null;
        }

        public async ValueTask<IEnumerable<CurrencyEntity>> GetAllFromDataBaseAsync()
        {
            // Get objects of previos day
            var currencies = await GetAllAsync();
            var date = currencies.First().Date.Day - 1;

            var result = await this.appDbContext.Currencies.Where(currency => currency.Date.Day == date).ToListAsync();

            return result;
        }
    }
}
