using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.DB
{
    class Moods
    {
        public int MoodId { get; set; }
        public string Description { get; set; }
        public List<Notes> NotesList { get; set; }
    }
}
