using Currency.Core.Interfaces;
using Currency.Core.Services;
using Currency.Desktop.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Currency.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Window
    {
        private readonly MessageView messageView;
        private readonly ICurrencyService currencyService;
        public SettingPage()
        {
            messageView = new MessageView();
            currencyService = new CurrencyService();
            InitializeComponent();
        }

        private async void SettingBtn_Click(object sender, RoutedEventArgs e)
        {
            await currencyService.GetAllAsync();
        }
    }
}
