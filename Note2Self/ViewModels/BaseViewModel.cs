using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, вызываемое, когда у любого из потомков меняется свойство
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected void OnPropertyChanged([CallerMemberName] string propertyName = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Методы для команд

        /// <summary>
        /// Выполняет поманду, если флаг не поднят
        /// Если флаг true (= функция уже выполняется), то действие не выполняется
        /// Если флаг false (= функция не выполняется), то запускаем
        /// Когда действие завершается, флаг опускается
        /// </summary>
        /// <param name="updatingFlag">Булевый флаг</param>
        /// <param name="action">Выполняемое действие</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // Если флаг true (= функция уже выполняется), выходим
            if (updatingFlag.GetPropertyValue())
                return;

            // Устанавливаем флаг в true (начинаем выполнение действия)
            updatingFlag.SetPropertyValue(true);

            try
            {
                // Запуск переданного действия
                await action();
            }
            finally
            {
                // По завершению действия опускаем флаг
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
