using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.Repositories
{
    public interface IUsersRepository : IRepository<Users>
    {
        //bool RegisterUser(string username, string password);
        //bool AuthorizeUser(string username, string password);
    }
}
