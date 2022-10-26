using System;
using System.Diagnostics;

namespace Currency.Mobile.ViewModels
{
    public class CurrencyDetailViewModel : BaseViewModel
    {
        private string id;
        private string name;
        private string abbreviation;
        private string officialRate;
        private string scale;
        private string date;
        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Abbreviation
        {
            get => abbreviation;
            set => SetProperty(ref abbreviation, value);
        }

        public string OfficialRate
        {
            get => officialRate;
            set => SetProperty(ref officialRate, value);
        }

        public string Scale
        {
            get => scale;
            set => SetProperty(ref scale, value);
        }

        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string CurrencyId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                LoadCurrencyId(value);
            }
        }

        public async void LoadCurrencyId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id.ToString();
                Abbreviation = item.Abbreviation;
                OfficialRate = item.OfficialRate.ToString();
                Scale = item.Scale.ToString();
                Date = item.Date.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
