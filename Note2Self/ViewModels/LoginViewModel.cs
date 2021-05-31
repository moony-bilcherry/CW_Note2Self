using Note2Self.Commands;
using Note2Self.DB;
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
        public UpdateViewCommand UpdateView { get => _updateView; set => Set(ref _updateView, value); }

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }


        #endregion

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
            var factories = new Dictionary<string, Func<BaseViewModel>>
            {
                {"Register", () => new RegisterViewModel() },
                {"Authorize", () => new HomeViewModel() }
            };

            UpdateView = new UpdateViewCommand(this, factories);

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
                //await Task.Delay(3000);

                //if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                //{
                //    MessageBox.Show("Убедитесь, что правильно заполнили поля");
                //    return;
                //}
                MessageBox.Show("КНОПКА ВОЙТИ");
                //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Home;
                await Task.Delay(1000);
                UpdateView.Execute("Authorize");
            });
        }

        public async Task Register()
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                //MessageBox.Show(DataWorker.CreateUser(Login, Password));
                MessageBox.Show("ХАЧЮ СОЗДАТЬ АКК");
                await Task.Delay(1000);
                //SelectedViewModel = new RegisterViewModel();
                //UpdateView = new UpdateViewCommand(this, "Register");
                UpdateView.Execute("Register");
            });
        }

    }
}
