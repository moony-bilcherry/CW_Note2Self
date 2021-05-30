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
    public class LoginViewModel : BaseViewModel
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
        public ICommand TestCommand { get; set; }

        #endregion

        #region Конструктор

        public LoginViewModel()
        {
            SelectedViewModel = new CalendarViewModel();
            UpdateView = new UpdateViewCommand(this);

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

                if (Login == null || String.IsNullOrWhiteSpace(Login) || Password == null || String.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Убедитесь, что правильно заполнили поля");
                    return;
                }
                //MessageBox.Show("ЯЯЯ авторизация!! LoginIsRunning: " + LoginIsRunning.ToString());
                ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Home;
                await Task.Delay(3000);
            });
        }

        public async Task Register()
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(3000);

                if (Login == null || String.IsNullOrWhiteSpace(Login) || Password == null || String.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Убедитесь, что правильно заполнили поля");
                    return;
                }

                //MessageBox.Show(DataWorker.CreateUser(Login, Password));
                MessageBox.Show("ЯЯЯ регистрация!!");
            });
        }

    }
}
