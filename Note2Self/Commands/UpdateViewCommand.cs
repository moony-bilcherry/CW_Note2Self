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
        private HomeViewModel viewModel;

        public UpdateViewCommand(HomeViewModel viewModel) => this.viewModel = viewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;
 

        public void Execute(object parameter) 
            => viewModel.SelectedViewModel = parameter.ToString() switch
        {
            "Calendar" => new CalendarViewModel(),
            "Notes" => new NotesViewModel(),
            "Goals" => new GoalsViewModel(),
            _ => throw new ArgumentException($"{nameof(parameter)}: {parameter}")
        };
    }
}
