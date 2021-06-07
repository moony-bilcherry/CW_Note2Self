using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Note2Self.ViewModels
{

    public class GoalViewModel : BaseViewModel
    {

        private Goals model;
        public Goals Model { get => model; set => Set(ref model, value); }


        private DateTime day;
        public DateTime Day { get => day; set => Set(ref day, value); }


    }
    public class GoalsViewModel : BaseViewModel
    {
        public IEnumerable<GoalViewModel> AllNotes { get; set; } = DataWorker
            .GetAllGoals()
            .Select(g => new GoalViewModel() { Day = g.day, Model = g.goal });


        public ICollectionView NotesView { get; set; }

        public GoalsViewModel()
        {
            NotesView = CollectionViewSource.GetDefaultView(AllNotes);
        }
    }
}
