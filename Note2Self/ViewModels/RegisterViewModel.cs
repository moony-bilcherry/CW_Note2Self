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
    public class RegisterViewModel : BaseViewModel, INestedViewModel
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

        public bool RegisterIsRunning { get; set; }
        public bool GoBackIsRunning { get; set; }

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
                await Task.Delay(3000);
                MessageBox.Show("ТЕСТ КНОПКИ ПОДТВЕРДИТЬ");
            });
        }

        public async Task GoBack()
        {
            await RunCommand(() => GoBackIsRunning, async () =>
            {
                MessageBox.Show("ЧЕРЕЗ СЕКУНДУ ПОЙДЕМ НАЗАД");
                await Task.Delay(1000);
            });
        }
    }
}
