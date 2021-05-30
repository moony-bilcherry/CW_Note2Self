using Note2Self.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self
{
    public static class DataWorker
    {
        #region Списки

        // Получить всех пользователей
        public static List<Users> GetAllUsers()
        {
            using (ContextDB db = new ContextDB())
            {
                return db.Users.ToList();
            }
        }

        // Получить все записки
        public static List<Notes> GetAllNotes()
        {
            using (ContextDB db = new ContextDB())
            {
                return db.Notes.ToList();
            }
        }

        // Получить все цели
        public static List<Goals> GetAllGoals()
        {
            using (ContextDB db = new ContextDB())
            {
                return db.Goals.ToList();
            }
        }

        #endregion

        #region Users

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        public static string CreateUser(string username, string password)
        {
            using (ContextDB db = new ContextDB())
            {
                /// <summary>
                /// Если пользователя с таким логином нет, добавляем его
                /// </summary>
                if (db.Users.Any(el => el.Username == username))
                    return ("Пользователь с логином " + username + " уже есть");

                Users newUser = new Users { Username = username, Password = password };
                db.Users.Add(newUser);
                db.SaveChanges();
                return "Пользователь " + username + " успешно зарегистрирован";
            }
        }        



        #endregion

        #region Записки ?????????????
        /// <summary>
        /// Добавление новой записки
        /// </summary>
        public static string CreateNote(DateTime day, string text, PossibleMoods mood)
        {
            using (ContextDB db = new ContextDB())
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
            using (ContextDB db = new ContextDB())
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
            using (ContextDB db = new ContextDB())
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
            using (ContextDB db = new ContextDB())
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
            using (ContextDB db = new ContextDB())
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
            using (ContextDB db = new ContextDB())
            {
                db.Goals.Remove(goal);
                db.SaveChanges();
                return ("Цель успешно удалена");
            }
        }

        #endregion




    }
}
