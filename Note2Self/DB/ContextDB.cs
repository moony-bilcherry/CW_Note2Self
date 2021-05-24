﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.DB
{
    class ContextDB : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Moods> Moods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>()
                .HasKey(c => c.NoteId);
            modelBuilder.Entity<Users>()
                .HasKey(c => c.UserId);
            modelBuilder.Entity<Moods>()
                .HasKey(c => c.MoodId);
            modelBuilder.Entity<Goals>()
                .HasKey(c => c.GoalId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=MOONY-SHTO;Initial Catalog=Note2Self;Integrated Security=True");
        }
    }
}
