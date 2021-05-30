using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private DateTime _selectedDate;
        public DateTime SelectedDate { get => _selectedDate; 
            set => Set(ref _selectedDate, value); }


        private SelectedDateViewModel selectedDateViewModel;
        public SelectedDateViewModel SelectedDateViewModel
        {
            get => selectedDateViewModel;
            set => Set(ref selectedDateViewModel, value);
        }
        public CalendarViewModel()
        {

        }
    }
}
