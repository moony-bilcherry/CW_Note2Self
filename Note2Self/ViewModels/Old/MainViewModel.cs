using Note2Self.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Note2Self.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Приватные поля
        
        private BaseViewModel _selectedViewModel = new WelcomeViewModel();
        #endregion


        
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { 
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            
        }
    }
}
