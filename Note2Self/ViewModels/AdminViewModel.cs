using Note2Self.Commands;
using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Note2Self.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        public IEnumerable<Users> AllUsers { get; set; } = DataWorker.GetAllUsers();

        private Users selectedUser;
        public Users SelectedUser { get => selectedUser; set => Set(ref selectedUser, value); }

        public ICollectionView UsersView { get; set; }

        private string searchString;
        public string SearchString { get => searchString; set => Set(ref searchString, value); }

        public ICommand SearchCommand { get; set; }

        private void Sort()
        {
            UsersView.Filter = (obj) =>
            {
                if (obj is Users user)
                {
                    return SearchString is null || user.Username.ToLower().Contains(SearchString.ToLower());
                }
                return false;
            };
        }

        public AdminViewModel()
        {
            UsersView = CollectionViewSource.GetDefaultView(AllUsers);
            SearchCommand = new RelayCommand(Sort); 
        }

    }
}
