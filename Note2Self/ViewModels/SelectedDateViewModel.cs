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
                using ContextDB context = new();

                if (HasNote)
                {
                    context.Notes.Update(Model);
                }
                else
                {
                    context.Notes.Add(Model);
                }

            });
        }
        public SelectedDateViewModel(DateTime date) : this()
        {


            using ContextDB context = new();

            var foundNote = context.Notes.FirstOrDefault(note => note.Day == date);

            Model = foundNote ?? new Notes();

            HasNote = foundNote is not null;
           
        }
       
    }
}
