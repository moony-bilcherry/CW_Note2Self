using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.DB
{
    class Goals
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int NotesId { get; set; }
        public Notes Notes { get; set; }
    }
}
