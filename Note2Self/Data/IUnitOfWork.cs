﻿using Note2Self.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        int Complete();
    }
}
