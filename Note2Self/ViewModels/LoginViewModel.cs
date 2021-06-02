using Note2Self.Commands;
using Note2Self.Models;
using Note2Self.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Note2Self.ViewModels
{
    public class LoginViewModel : BaseViewModel, INestedViewModel
    {
        #region Для переключения вьюх

        private UpdateViewCommand _updateView;
        public UpdateViewCommand UpdateView { get => _updateView; 
            set => Set(ref _updateView, value); }

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }


        #endregion

        #region Приватные поля

        private string login;
        private string password;
        private bool loginIsRunning;
        private bool registerIsRunning;


        #endregion

        #region Публичные свойства

        public string Login { get => login; set => Set(ref login, value); }

        public string Password { get => password; set => Set(ref password, value); }

        public bool LoginIsRunning { get => loginIsRunning; set => Set(ref loginIsRunning, value); }

        public bool RegisterIsRunning { get => registerIsRunning; set => Set(ref registerIsRunning, value); }

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
            AuthorizeCommand = new RelayCommand(async () => await Authorize());

            OnPropertyChanged(nameof(AuthorizeCommand));
            OnPropertyChanged(nameof(RegisterCommand));
        }

        #endregion

        public async Task Authorize()
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                if(!DataWorker.Authorize(Login, Password))
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
                DataWorker.CurrentUser = DataWorker.GetUser(Login);
                UpdateView.Execute("Home");
                await Task.Delay(0);
            });
        }

        public async Task Register()
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(0);
                UpdateView.Execute("Register");
            });
        }

    }
}
