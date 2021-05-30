﻿using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.DB
{
    public class Users : BindableBase
    {
        public int Id { get; set; }

        private string username;
        public string Username { get => username; set => Set(ref username, value); }


        private string password;
        public string Password { get => password; set => Set(ref password, value); }


        private List<Notes> notesList;
        public List<Notes> NotesList { get => notesList; set => Set(ref notesList, value); }
    }
}