using Note2Self.Models;
using Note2Self.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Note2SelfContext _context;
        public UnitOfWork(Note2SelfContext context)
        {
            _context = context;
            Users = new UsersRepository(_context);
            Notes = new NotesRepository(_context);
            Goals = new GoalsRepository(_context);
        }
        public IUsersRepository Users { get; private set; }
        public INotesRepository Notes { get; private set; }
        public IGoalsRepository Goals { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
