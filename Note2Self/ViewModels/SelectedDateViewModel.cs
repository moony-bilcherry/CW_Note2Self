using Note2Self.Commands;
using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ViewModels
{
    public class SelectedDateViewModel : BaseViewModel
    {
        public DateTime Date { get; set; }

        public Array Moods { get; set; } = Enum.GetValues<PossibleMoods>();

        //private PossibleMoods selectedMood;
        //public PossibleMoods SelectedMood { get => selectedMood; set => Set(ref selectedMood, value); }

        public Notes Model { get; set; }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get => saveCommand;
            set => Set(ref saveCommand, value);
        }
        public bool HasNote;


        public SelectedDateViewModel()
        {
            SaveCommand = new RelayCommand(() =>
            {
                DataWorker.AddNote(Model);
            });
        }

        public SelectedDateViewModel(DateTime date) : this()
        {

            var foundNote = DataWorker.GetNote(date);

            Model = foundNote ?? new Notes();
            HasNote = foundNote is not null;
            if (!HasNote) Model.Day = date;
        }
       
    }
}
