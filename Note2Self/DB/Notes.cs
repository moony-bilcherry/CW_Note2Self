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
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Day { get; set; }
        public PossibleMoods Mood { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public List<Goals> Goals { get; set; }
    }
}
