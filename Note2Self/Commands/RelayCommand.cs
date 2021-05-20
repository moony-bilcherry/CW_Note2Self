using System;
using System.Windows.Input;

namespace Note2Self.Commands
{
    /// <summary>
    /// Стандартная команда, выполняющая действие
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Приватные поля

        /// <summary>
        /// Выполняемое действие
        /// </summary>
        private Action _action;

        #endregion

        #region Публичные события

        /// <summary>
        /// Событие, вызываемое, когда значение <see cref="CanExecute(object)"/> изменилось
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RelayCommand(Action action)
        {
            _action = action;
        }

        #endregion

        #region Методы команды

        /// <summary>
        /// Эта команда всегда выполняется
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполняет переданное командой действие
        /// </summary>
        public void Execute(object parameter)
        {
            _action();
        }

        #endregion
    }
}