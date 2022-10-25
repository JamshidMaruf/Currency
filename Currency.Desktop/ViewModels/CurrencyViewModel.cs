using Currency.Desktop.Commands;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
