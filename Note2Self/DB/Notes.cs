using Note2Self.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.DB
{
    class Notes
    {
        public Users User { get; set; }
        public int NoteId { get; set; }
        public DateTime DateCreated { get; set; }
        public string NoteData { get; set; }
        public Moods Mood { get; set; }
        public Goals Goal { get; set; }
    }
}
