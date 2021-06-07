using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.Models
{
    public class Notes : BindableBase, IEntity
    {
        public int Id { get; set; }


        private string text;
        public string Text { get => text; set => Set(ref text, value); }


        private DateTime day;
        public DateTime Day { get => day; set => Set(ref day, value); }

        private PossibleMoods mood;
        public PossibleMoods Mood { get => mood; set => Set(ref mood, value); }

        public int UserId { get; set; }

        private byte[] cover;
        public byte[] Cover { get => cover; set => Set(ref cover, value); }

        private Users user;
        public Users User { get => user; set => Set(ref user, value); }

        private List<Goals> goals = new List<Goals>();
        public List<Goals> Goals { get => goals; set => Set(ref goals, value); }
    }
}
