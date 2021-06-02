using Note2Self.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Note2Self.ViewModels
{
    public class RegisterViewModel : BaseViewModel 
    {

        #region Для переключения вьюх

        private UpdateViewCommand _updateView;
        public UpdateViewCommand UpdateView { 
            get => _updateView; 
            set => Set(ref _updateView, value); }


        #endregion

        #region Приватные поля


        private string login;
        private string password;
        private bool registerIsRunning;
        private bool goBackIsRunning;
        private string repeatPassword;

        #endregion

        #region Публичные свойства

        public bool RegisterIsRunning { get => registerIsRunning; set => Set(ref registerIsRunning, value); }

        public bool GoBackIsRunning { get => goBackIsRunning; set => Set(ref goBackIsRunning, value); }
        public string Login { get => login; set => Set(ref login, value); }

        public string Password { get => password; set => Set(ref password, value); }

        public string RepeatPassword { get => repeatPassword; set => Set(ref repeatPassword, value); }

        #endregion

        #region Команды

        public ICommand RegisterCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        #endregion

        #region Конструктор

        public RegisterViewModel()
        {

            //UpdateView = new UpdateViewCommand(this);

            RegisterCommand = new RelayCommand(async () => await Register());
            GoBackCommand = new RelayCommand(async () => await GoBack());

            OnPropertyChanged(nameof(RegisterCommand));
            OnPropertyChanged(nameof(GoBackCommand));
        }

        #endregion

        public async Task Register()
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(RepeatPassword))
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }
                if (Password != RepeatPassword)
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }
                MessageBox.Show(DataWorker.RegisterUser(Login, Password));
                await Task.Delay(200);
                UpdateView.Execute("Login");
            });
        }

        public async Task GoBack()
        {
            await RunCommand(() => GoBackIsRunning, async () =>
            {
                await Task.Delay(0);
                UpdateView.Execute("Login");
            });
        }
    }
}
