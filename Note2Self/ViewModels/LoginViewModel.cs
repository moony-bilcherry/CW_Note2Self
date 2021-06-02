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
                var res = DataWorker.Authorize(Login, Password);

                if (res == "OK")
                {
                    DataWorker.CurrentUser = DataWorker.GetAllUsers().First(u => u.Username == Login);
                    UpdateView.Execute("Home");
                }
                else MessageBox.Show(res);
                //await Task.Delay(3000);

                //if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                //{
                //    MessageBox.Show("Убедитесь, что правильно заполнили поля");
                //    return;
                //}
                 
                //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Home;
                await Task.Delay(0);
              
            });
        }

        public async Task Register()
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
             
                MessageBox.Show("ХАЧЮ СОЗДАТЬ АКК");
                await Task.Delay(1000);
                //SelectedViewModel = new RegisterViewModel();
                //UpdateView = new UpdateViewCommand(this, "Register");
                UpdateView.Execute("Register");
            });
        }

    }
}
