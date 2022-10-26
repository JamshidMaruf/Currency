using Currency.Mobile.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Currency.Mobile.ViewModels
{
    public class CurrencyViewModel : BaseViewModel
    {
        private CurrencyEntity _selectedCurrency;

        public ObservableCollection<CurrencyEntity> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<CurrencyEntity> ItemTapped { get; }

        public CurrencyViewModel()
        {

            Items = new ObservableCollection<CurrencyEntity>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<CurrencyEntity>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCurrency = null;
        }

        public CurrencyEntity SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                SetProperty(ref _selectedCurrency, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(CurrencyEntity item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{""}?{nameof(CurrencyDetailViewModel.Id)}={item.Id}");
        }

    }
}
