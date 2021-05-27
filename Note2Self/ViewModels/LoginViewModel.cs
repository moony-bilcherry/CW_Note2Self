using Note2Self.Commands;
using Note2Self.DB;
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

        public bool LoginIsRunning { get; set; }
        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Команды

        public ICommand AuthorizeCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Конструктор

        public LoginViewModel()
        {
            // Создание команд 
            RegisterCommand = new RelayCommand(async () => await Register());
            RegisterCommand = new RelayCommand(async () => await Authorize());

            OnPropertyChanged(nameof(RegisterCommand));
        }

        #endregion

        public async Task Authorize()
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(3000);

                if (Login == null || Login.Replace(" ", "").Length == 0 || Password == null || Password.Replace(" ", "").Length == 0)
                {
                    MessageBox.Show("Убедитесь, что правильно заполнили поля");
                    return;
                }
                MessageBox.Show("Vse harasho!!");
            });
        }

        public async Task Register()
        {
            await RunCommand(() => this.RegisterIsRunning, async () =>
            {
                await Task.Delay(3000);

                if (Login == null || Login.Replace(" ", "").Length == 0 || Password == null || Password.Replace(" ", "").Length == 0)
                {
                    MessageBox.Show("Убедитесь, что правильно заполнили поля");
                    return;
                }

                //MessageBox.Show(DataWorker.CreateUser(Login, Password));
                MessageBox.Show("Vse harasho!!");
            });
        }

    }
}
