using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.DB
{
    class Goals
    {
        public int GoalId { get; set; }
        public int NoteId { get; set; }
        public int Description { get; set; }
        public Notes Notes { get; set; }
    }
}
