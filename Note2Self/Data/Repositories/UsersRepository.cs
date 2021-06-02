using Note2Self.Models;
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

        //public bool AuthorizeUser(string username, string password)
        //{
        //    if(Note2SelfContext.Users.FirstOrDefault(u=>u.Username == username) is Users user)
        //    {
        //        if(user.Password == password)
        //        {
        //            MessageBox.Show("Успешный вход!");
        //            return true;
        //        }
        //        MessageBox.Show("Неверный пароль");
        //        return false;
        //    }
        //    MessageBox.Show($"Пользователь {username} не существует");
        //    return false;
        //}

        //public bool RegisterUser(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
