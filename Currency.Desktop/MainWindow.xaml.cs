using Currency.Core.Models;
using Currency.Core.Services;
using Currency.Desktop.Controls;
using Currency.Desktop.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Currency.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

#pragma warning disable
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

    private void SettingButton_Click(object sender, RoutedEventArgs e)
    {
        SettingWindow settingWindow = new SettingWindow();
        this.Visibility = Visibility.Hidden;
        settingWindow.Show();
    }

    private async Task LoadCurrencies(IEnumerable<CurrencyEntity> currencies)
    {
        foreach (var currency in currencies)
        {
            await this.Dispatcher.InvokeAsync(() =>
            {
                Item item = new();
                item.Cur_Abbreviation.Text = currency.Abbreviation;
                item.Cur_OfficialRate.Text = currency.OfficialRate.ToString();
                item.Cur_OfficialRate2.Text = currency.OfficialRate.ToString();
                item.Cur_Scale.Text = currency.Scale.ToString() + " " + currency.Name;
                today.Text = currencies.First().Date.ToString("dd.M.yy");
                previousDay.Text = currencies.First().Date.ToString("dd.M.yy");

                CurrenciesList.Items.Add(item);
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

    private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.Close();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private bool IsMaximized = false;
    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (IsMaximized)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 600;
                this.Height = 700;

                IsMaximized = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;

                IsMaximized = true;
            }
        }
    }

    private async void GetPreviousDayData()
    {
        var cc = await currencyService.GetAllFromDataBaseAsync();
        previousDay.Text = cc.First().Date.Day.ToString();
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void btnRestore_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
            WindowState = WindowState.Maximized;
        else
            WindowState = WindowState.Normal;
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
}
