using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.Models
{
    public class Goals : BindableBase, IEntity
    {

         
        public int Id { get; set; }

        private string description;
        public string Description { get => description; set => Set(ref description, value); }

        public int NotesId { get; set; }

        private Notes notes;
        public Notes Notes { get => notes; set => Set(ref notes, value); }
    }
}
