using Note2Self.DB;
using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.DB
{
    public class Notes : BindableBase
    {
        public int Id { get; set; }


        private string text;
        public string Text { get => text; set => Set(ref text, value); }


        private DateTime day;
        public DateTime Day { get => day; set => Set(ref day, value); }

        private PossibleMoods mood;
        public PossibleMoods Mood { get => mood; set => Set(ref mood, value); }
        public int UserId { get; set; }

        private Users user;
        public Users User { get => user; set => Set(ref user, value); }

        private List<Goals> goals;
        public List<Goals> Goals { get => goals; set => Set(ref goals, value); }
    }
}
