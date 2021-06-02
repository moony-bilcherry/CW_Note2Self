using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.Repositories
{
    public class NotesRepository : Repository<Notes>, INotesRepository
    {
        public NotesRepository(Note2SelfContext context) : base(context)
        {

        }

        public Note2SelfContext Note2SelfContext
        {
            get { return Context as Note2SelfContext; }
        }
    }
}
