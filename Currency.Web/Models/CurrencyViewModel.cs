using Currency.Core.Models;

namespace Currency.Web.Models;

#pragma warning disable
public class CurrencyViewModel
{
    public List<CurrencyEntity> Currencies { get; set; }
    public string? Search { get; set; }
}
