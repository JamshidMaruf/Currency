using System;

namespace Currency.Mobile.Models
{
    public class CurrencyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public decimal OfficialRate { get; set; }

        public int Scale { get; set; }

        public DateTime Date { get; set; }
    }
}
