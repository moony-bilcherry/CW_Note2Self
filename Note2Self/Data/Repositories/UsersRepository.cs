﻿using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Note2Self.Repositories
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(Note2SelfContext context) : base(context)
        {

        }

        public Note2SelfContext Note2SelfContext
        {
            get { return Context as Note2SelfContext; }
        }
    }
}
