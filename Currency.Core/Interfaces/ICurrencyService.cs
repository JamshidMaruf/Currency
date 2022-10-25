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
    /// Add to database
    /// </summary>
    /// <returns></returns>
    ValueTask AddAsync();

    /// <summary>
    /// Get all currency objects which are suitable from database
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<CurrencyEntity>> GetAllFromDataBaseAsync();

    /// <summary>
    /// Get all currency objects date from json
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<CurrencyEntity>> GetAllAsync();
}
