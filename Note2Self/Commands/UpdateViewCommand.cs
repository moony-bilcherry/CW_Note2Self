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
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //if(parameter.ToString() == "Home")
            //{
            //    viewModel.SelectedViewModel = new HomeViewModel();
            //}
            if (parameter.ToString() == "Register")
            {
                viewModel.SelectedViewModel = new RegisterViewModel();
            }
            if (parameter.ToString() == "Welcome")
            {
                viewModel.SelectedViewModel = new WelcomeViewModel();
            }
        }
    }
}
