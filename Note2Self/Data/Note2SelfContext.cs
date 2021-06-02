using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.Models
{
    public class Note2SelfContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Goals> Goals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Notes>()
            //    .HasKey(c => c.NoteId);
            //modelBuilder.Entity<Users>()
            //    .HasKey(c => c.UserId);
            //modelBuilder.Entity<Goals>()
            //    .HasKey(c => c.GoalId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //dbContextOptionsBuilder.UseSqlServer(@"Data Source=MOONY-SHTO;Initial Catalog=Note2Self;Integrated Security=True");
           dbContextOptionsBuilder.UseSqlServer(@"Server=tcp:note2selfserver.database.windows.net,1433;Initial Catalog=app;Persist Security Info=False;User ID=moony;Password=Pamag1te;");
        }
    }
}
