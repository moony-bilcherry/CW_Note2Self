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
        private static UnitOfWork unitOfWork = new UnitOfWork(new Note2SelfContext());

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

        public static Users CurrentUser;
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

        #region Записки ?????????????



        public static Notes GetNote(DateTime date)
        {
            return unitOfWork.Notes.GetAll().FirstOrDefault(el => el.Day == date);
        }

        /// <summary>
        /// Добавление новой записки
        /// </summary>
        public static void AddNote(Notes note)
        {
            if (unitOfWork.Notes.GetAll().Any(el => el.Day == note.Day))
            {
                unitOfWork.Notes.Update(note);
            }
            else
            {
                CurrentUser.NotesList.Add(note);
                unitOfWork.Users.Update(CurrentUser);
            }
            unitOfWork.Complete();
        }

        /// <summary>
        /// Изменение записки
        /// </summary>
        public static string EditNote(DateTime day, string text, PossibleMoods mood)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                Notes newNote = new Notes { Day = day, Text = text, Mood = mood };
                db.Notes.Add(newNote);
                db.SaveChanges();
                return "Записка успешно добавлена";
            }
        }

        /// <summary>
        /// Удаление записки
        /// </summary>
        public static string DeleteNote(Notes note)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                db.Notes.Remove(note);
                db.SaveChanges();
                return ("Записка за " + note.Day.ToString() + " успешно удалена");
            }
        }

        #endregion

        #region Цели

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
