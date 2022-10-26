using System.Windows;

namespace Currency.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for MessageView.xaml
    /// </summary>
    public partial class MessageView : Window
    {
        public MessageView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
