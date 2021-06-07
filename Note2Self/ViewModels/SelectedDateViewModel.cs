using Microsoft.Win32;
using Note2Self.Commands;
using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Note2Self.ViewModels
{
    public class SelectedDateViewModel : BaseViewModel
    {
        public DateTime Date { get; set; }

        public Array Moods { get; set; } = Enum.GetValues<PossibleMoods>();


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

        public ICommand BrowseImageCommand => new DelegateCommand(
                     param => BrowseImageEvent()
                 );

        private void BrowseImageEvent()
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Image Files|*.jpg;*.png;*.bmp;*.tiff;"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Model.Cover = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

    }
}
