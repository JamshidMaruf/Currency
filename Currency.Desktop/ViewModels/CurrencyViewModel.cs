using Currency.Desktop.Commands;
using MVVMEssentials.ViewModels;
using System.Windows.Input;

namespace Currency.Desktop.ViewModels
{
    public class CurrencyViewModel : ViewModelBase
    {
        public ICommand SaveCommand { get; }
        public CurrencyViewModel()
        {
            SaveCommand = new SaveCommand();
        }
    }
}
