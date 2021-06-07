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
    public class NotesViewModel : BaseViewModel 
    {
        public IEnumerable<Notes> AllNotes { get; set; } = DataWorker.GetAllNotes();
        public ICollectionView NotesView { get; set; }

        public NotesViewModel()
        {
            NotesView = CollectionViewSource.GetDefaultView(AllNotes);
        }
    }
}
