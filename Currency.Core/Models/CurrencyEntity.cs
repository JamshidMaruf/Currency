using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Currency.Core.Models;

public class CurrencyEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonProperty("Cur_ID")]
    public int Id { get; set; }

    [JsonProperty("Cur_Name")]
    public string Name { get; set; }

    [JsonProperty("Cur_Abbreviation")]
    public string Abbreviation { get; set; }

    [JsonProperty("Cur_OfficialRate")]
    public decimal OfficialRate { get; set; }

    [JsonProperty("Cur_Scale")]
    public int Scale { get; set; }

    [JsonProperty("Date")]
    public DateTime Date { get; set; }
}
