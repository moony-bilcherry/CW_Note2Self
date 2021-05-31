using Note2Self.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Note2Self.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private INestedViewModel viewModel;

        public UpdateViewCommand(INestedViewModel viewModel) => this.viewModel = viewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;


        public void Execute(object parameter)
        {
            var t = Type.GetType($"{parameter}ViewModel");

        }

    }
}
