using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_Note2Self.DB
{
    class Notes
    {
        public int NoteId { get; set; }
        public string NoteData { get; set; }
        public Users User { get; set; }
    }
}
