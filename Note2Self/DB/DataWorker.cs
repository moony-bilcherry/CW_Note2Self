using Note2Self.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self
{
    class DataWorker
    {
        #region Добавление

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        public string CreateUser(string username, string password)
        {
            using (ContextDB db = new ContextDB())
            {
                /// <summary>
                /// Если пользователя с таким логином нет, добавляем его
                /// </summary>
                if (db.Users.Any(el => el.Username == username))
                    return "Такой пользователь уже есть";

                Users newUser = new Users { Username = username, Password = password };
                db.Users.Add(newUser);
                db.SaveChanges();
                return "Пользователь успешно добавлен";
            }
        }

        /// <summary>
        /// Добавление новой записки
        /// </summary>
        public string CreateNote( DateTime day, string text, PossibleMoods mood)
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
        /// Добавление новой цели
        /// </summary>
        public string CreateGoal(string text)
        {
            using (ContextDB db = new ContextDB())
            {
                Goals newGoal = new Goals { Description = text};
                db.Goals.Add(newGoal);
                db.SaveChanges();
                return "Цель успешно добавлена";
            }
        }

        #endregion

        #region Изменение



        #endregion




    }
}
