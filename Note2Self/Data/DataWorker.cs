using Microsoft.EntityFrameworkCore;
using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Note2Self
{
    public static class DataWorker
    {
       /// <summary>
       /// Связь с контекстом базы данных
       /// </summary>
        private static UnitOfWork unitOfWork = new UnitOfWork(new Note2SelfContext());

        /// <summary>
        /// Пользователь, зашедший в приложение
        /// </summary>
        public static Users CurrentUser;

        #region Конструктор

        static DataWorker()
        {
            
        }

        #endregion

        #region Users
        public static IEnumerable<Users> GetAllUsers()
        {
            return unitOfWork.Users.GetAllWithPropertiesIncluded();
        }

        public static Users GetUser(string username)
        {
            return unitOfWork.Users.GetAllWithPropertiesIncluded().FirstOrDefault(el => el.Username == username);
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>   
        public static string RegisterUser(string username, string password)
        {

            if (unitOfWork.Users.GetAll().Any(el => el.Username == username))
                return ("Пользователь с логином " + username + " уже есть");
            unitOfWork.Users.Add(new Users { Username = username, Password = password, Role = Roles.User });
            unitOfWork.Complete();
            return "Пользователь " + username + " успешно зарегистрирован";
        }

        public static bool Authorize(string username, string password) 
            => ((unitOfWork.Users.GetAll().FirstOrDefault(u => u.Username == username) is Users user) && user.Password == password);



        #endregion

        #region Notes 

        /// <summary>
        /// Получить все записки
        /// </summary>
        public static IEnumerable<Notes> GetAllNotes()
        {
            return unitOfWork.Notes.GetAllWithPropertiesIncluded().Where(el => el.UserId == CurrentUser.Id);
        }

        /// <summary>
        /// Получить записку на конкретный день
        /// </summary>
        public static Notes GetNote(DateTime date)
        {
            return unitOfWork.Notes.GetAllWithPropertiesIncluded().FirstOrDefault(el => el.Day == date && el.UserId == CurrentUser.Id);
        }

        #endregion

        #region Цели

        public static IEnumerable<(DateTime, Goals)> GetAllGoals()
        {
            return GetAllNotes().SelectMany<Notes,(DateTime,Goals)>(n => (n.Day, n.Goals));
        }

        /// <summary>
        /// Получить все записки
        /// </summary>
        //public static IEnumerable<Goals> GetAllGoals()
        //{
        //    return unitOfWork.Goals.GetAllWithPropertiesIncluded().Where(el => el.UserId == CurrentUser.Id);
        //}

        /// <summary>
        /// Добавление новой цели
        /// </summary>
        public static string CreateGoal(string text)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                Goals newGoal = new Goals { Description = text };
                db.Goals.Add(newGoal);
                db.SaveChanges();
                return "Цель успешно добавлена";
            }
        }

        /// <summary>
        /// Изменение цели
        /// </summary>
        public static string EditGoal(string text)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                Goals newGoal = new Goals { Description = text };
                db.Goals.Add(newGoal);
                db.SaveChanges();
                return "Цель успешно добавлена";
            }
        }

        /// <summary>
        /// Удаление цели
        /// </summary>
        public static string DeleteGoal(Goals goal)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                db.Goals.Remove(goal);
                db.SaveChanges();
                return ("Цель успешно удалена");
            }
        }

        #endregion




    }
}
