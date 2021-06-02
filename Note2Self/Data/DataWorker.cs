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
        #region Списки

        // Получить всех пользователей
        public static List<Users> GetAllUsers()
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                return db.Users.AsNoTracking().ToList();
            }
        }

        // Получить все записки
        public static List<Notes> GetAllNotes()
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                return db.Notes.AsNoTracking().ToList();
            }
        }

        // Получить все цели
        public static List<Goals> GetAllGoals()
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                return db.Goals.AsNoTracking().ToList();
            }
        }

        #endregion

        #region Users


        public static Users CurrentUser;
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        public static string CreateUser(string username, string password)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                /// <summary>
                /// Если пользователя с таким логином нет, добавляем его
                /// </summary>
                if (db.Users.Any(el => el.Username == username))
                    return ("Пользователь с логином " + username + " уже есть");

                Users newUser = new Users { Username = username, Password = password, Role = Roles.User };
                db.Users.Add(newUser);
                db.SaveChanges();
                return "Пользователь " + username + " успешно зарегистрирован";
            }
        }

                
        public static void RegisterUser(string username, string password)
        {
            string s = "Net takogo!";
            using (var unitOfWork = new UnitOfWork(new Note2SelfContext()))
            {

                //bool check = unitOfWork.Users.Equals(el=>el.Username=username);
                unitOfWork.Users.Add(new Users { Username = username, Password = password, Role = Roles.User });
                unitOfWork.Complete();
            }
        }



        public static string Authorize(string username, string password)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                if (db.Users.FirstOrDefault(u => u.Username == username) is Users user)
                {
                    if (user.Password == password)
                    {
                        return "OK";
                    }
                    else return "Неверный пароль";
                }
                else return $"Пользователь {username} не существует";
               
              
            }
        }



        #endregion

        #region Записки ?????????????
        /// <summary>
        /// Добавление новой записки
        /// </summary>
        public static string CreateNote(DateTime day, string text, PossibleMoods mood)
        {
            using (Note2SelfContext db = new Note2SelfContext())
            {
                /// <summary>
                /// Если записки на этот день нет, добавляем
                /// </summary>
                if (db.Notes.Any(el => el.Day == day))
                    return "Записка на этот день уже есть????";

                Notes newNote = new Notes { Day = day, Text = text, Mood = mood };
                db.Notes.Add(newNote);
                db.SaveChanges();
                return "Записка успешно добавлена";
            }
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
