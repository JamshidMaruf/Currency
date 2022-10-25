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
using System.Windows.Shapes;

namespace Currency.Desktop.Windows;

/// <summary>
/// Interaction logic for SettingWindow.xaml
/// </summary>
/// 
#pragma warning disable
public partial class SettingWindow : Window
{
    private readonly ICurrencyService currencyService;
    private Thread thread;
    public SettingWindow()
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
        MainWindow mainWindow = new MainWindow();
        this.Visibility = Visibility.Hidden;
        mainWindow.Show();
    }

    private async Task LoadCurrencies(IEnumerable<CurrencyEntity> currencies)
    {
        foreach (var currency in currencies)
        {
            await this.Dispatcher.InvokeAsync(() =>
            {
                SettingItem settingItem = new();
                settingItem.Cur_Abbreviation.Text = currency.Abbreviation;
                settingItem.Cur_Scale.Text = currency.Scale.ToString() + currency.Name;

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
    private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.Close();
    }

    private void CurrenciesList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Point point = e.GetPosition(null);
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
}
