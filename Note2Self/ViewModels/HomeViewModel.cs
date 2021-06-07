using Note2Self.Commands;
using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ViewModels
{
    public class HomeViewModel : BaseViewModel, INestedViewModel
    {
        public Roles CurrentUserRole { get; set; }

        private UpdateViewCommand _updateView;
        public UpdateViewCommand UpdateView { get => _updateView; set => Set(ref _updateView, value); }

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel {get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value); }

        public HomeViewModel()
        {
            CurrentUserRole = DataWorker.CurrentUser.Role;
            //var factories = new Dictionary<string, Func<BaseViewModel>>
            //{
            //    {"Calendar", () => new CalendarViewModel() },
            //    {"Notes", () => new NotesViewModel() },
            //    {"Goals", () => new GoalsViewModel() }
            //};
           
            //UpdateView = new UpdateViewCommand(this, factories);


            SelectedViewModel = new CalendarViewModel();
        }
    }
}
