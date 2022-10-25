using Currency.Core.Interfaces;
using Currency.Core.Models;
using Currency.Core.Services;
using Currency.Desktop.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Currency.Desktop.Pages;

/// <summary>
/// Interaction logic for SettingPage.xaml
/// </summary>

#pragma warning disable
public partial class SettingPage : Page
{

    private readonly ICurrencyService currencyService;
    private Thread thread;
    public SettingPage()
    {
        this.currencyService = new CurrencyService();
        InitializeComponent();
    }

    private IEnumerable<CurrencyEntity> currencies;

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Visibility = Visibility.Hidden;
        mainWindow.Show();
    }

    private void CheckButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private async Task LoadCurrencies(IEnumerable<CurrencyEntity> currencies)
    {
        foreach (var currency in currencies)
        {
            await this.Dispatcher.InvokeAsync(() =>
            {
                SettingItem settingItem = new SettingItem();
                settingItem.Cur_Abbreviation.Text = currency.Abbreviation;
                settingItem.Cur_Scale.Text = currency.Scale.ToString() + " " + currency.Name;

                CurrenciesList.Items.Add(settingItem);
            });
        }
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        thread = new Thread(async () =>
        {
            Dispatcher.Invoke(() => CurrenciesList.Items.Clear());

            currencies = await currencyService.GetAllAsync();

            await LoadCurrencies(currencies);
        });

        thread.Start();
    }
}
