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
        private IDictionary<string, Func<BaseViewModel>> factories;

        public UpdateViewCommand(INestedViewModel viewModel, IDictionary<string, Func<BaseViewModel>> factories) => (this.viewModel, this.factories) = (viewModel, factories);

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;


        public void Execute(object parameter)
        {
            //var t = Type.GetType($"{parameter}ViewAModel");
            if (factories.TryGetValue(parameter.ToString(), out var factory))
            {
                viewModel.SelectedViewModel = factory();
            }
            else throw new ArgumentException($"{nameof(parameter)} был {parameter}");
        }

 
    }
}
