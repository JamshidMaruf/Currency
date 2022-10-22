using Currency.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Core.Interfaces;

public interface ICurrencyService
{
    /// <summary>
    /// Get all currency objects from json
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<CurrencyEntity>> GetAllAsync(); 
}
