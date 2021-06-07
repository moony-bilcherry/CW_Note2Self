using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Note2Self.Commands
{
    public class DelegateCommand : ICommand
    {

        readonly Action<object> execute;
        readonly Predicate<object> canExecute;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {

            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameters)
            => canExecute is null || canExecute(parameters);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameters) => execute(parameters);
    }
}
