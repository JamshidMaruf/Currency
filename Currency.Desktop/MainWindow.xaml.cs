using Currency.Core.Models;
using Currency.Core.Services;
using Currency.Desktop.Controls;
using Currency.Desktop.Pages;
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

namespace Currency.Desktop;

#pragma warning disable
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly CurrencyService currencyService;
    private Thread thread;
    public MainWindow()
    {
        currencyService = new CurrencyService();
        InitializeComponent();
    }

    private IEnumerable<CurrencyEntity> currencies;

    private void SettingBtn_Click(object sender, RoutedEventArgs e)
    {
        InputerArea.Content = new SettingPage();
    }

    private async Task LoadCurrencies(IEnumerable<CurrencyEntity> currencies)
    {
        foreach(var currency in currencies)
        {
            await this.Dispatcher.InvokeAsync(() =>
            {
                Item item = new();

                item.Cur_Name.Text = currency.Name;
                item.Cur_Abbreviation.Text = currency.Abbreviation;
                item.Cur_OfficialRate.DataContext = currency.OfficialRate;
                item.Cur_Scale.DataContext = currency.Scale;

                CurrenciesList.Items.Add(item);
            });
        }
    }

    private void SaveBtn_Click()
    {

    }
    private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.Close();
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
