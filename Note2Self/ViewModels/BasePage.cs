using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Note2Self
{
    /// <summary>
    /// Базовый класс для всех страниц
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Приватные поля

        /// <summary>
        /// Вьюмодель, связанная с этой страницей
        /// </summary>
        private VM _viewModel;

        #endregion


        #region Публичные свойства

        /// <summary>
        /// Вьюмодель, связанная с этой страницей
        /// </summary>
        public VM ViewModel 
        { 
            get 
            {
                return _viewModel;
            }
            set
            {
                // Если ничего не изменилось, возвращаемся
                if (_viewModel == value)
                    return;

                // Обновляем значение
                _viewModel = value;

                // Устанавливаем контект данных
                this.DataContext = _viewModel;
            }
        }

        #endregion


        public BasePage()
        {
            //this.Loaded += BasePage_Loaded;

            // Устанавливаем вьюмодель
            this.ViewModel = new VM();
        }

        private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
