using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ViewModels
{
    class WelcomeViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new RegisterViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; }
        }
    }
}
