using Currency.Core.Interfaces;
using Currency.Core.Services;
using Currency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Currency.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyService currencyService;
        public HomeController(ILogger<HomeController> logger)
        {
            this.currencyService = new CurrencyService();
            _logger = logger;
        }

        public async ValueTask<IActionResult> Index(string searchString)
        {
            var currencies = await this.currencyService.GetOrderedItemsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToUpper();
                //currencies = currencies.Where(p => p.Abbreviation.Contains(searchString));
            }

            return View(currencies);
        }

        public async ValueTask<IActionResult> Setting()
        {
            var currencies = await this.currencyService.GetOrderedItemsAsync();
            return View(currencies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}