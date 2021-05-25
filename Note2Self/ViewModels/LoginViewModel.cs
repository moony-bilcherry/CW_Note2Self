using Note2Self.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Note2Self
{
    public class LoginViewModel : BaseViewModel
    {
        

        #region Приватные поля

        

        #endregion

        #region Публичные свойства

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion

        #region Команды

        public ICommand LoginCommand { get; set; }

        #endregion

        #region Конструктор

        public LoginViewModel()
        {
            // Создание команд
            //LoginCommand = new RelayCommand(() => );
        }

        #endregion


    }
}
