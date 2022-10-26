using MVVMEssentials.Commands;
using System.Windows;

namespace Currency.Desktop.Commands
{
    public class SaveCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show("Successfully saved");
        }
    }
}
