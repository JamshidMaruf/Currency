using Currency.Mobile.ViewModels;
using Xamarin.Forms;

namespace Currency.Mobile
{
    public partial class MainPage : ContentPage
    {
        CurrencyViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CurrencyViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}
