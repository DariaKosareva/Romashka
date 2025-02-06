using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Ромашка
{
    public class database
    {
        public interface IUser
        {
            string Name { get; set; }
            string LastName { get; set; }
            string FatherName { get; set; }
            string Login { get; set; }
            string Telephone { get; set; }
            string Password { get; set; }
            string Email { get; set; }
        }

        public interface IDatabaseHelper
        {
            List<IUser> GetAllUsers();
        }

        public class User : IUser
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string FatherName { get; set; }
            public string Login { get; set; }
            public string Telephone { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        public class DatabaseHelper : IDatabaseHelper
        {
            private SQLiteConnection connection;
            private string connectionString = "DataSource=Teacher.db";

            public DatabaseHelper()
            {
                connection = new SQLiteConnection(connectionString);
            }

            public List<IUser> GetAllUsers()
            {
                List<IUser> users = new List<IUser>();

                string query = "SELECT * FROM Users";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        IUser user = new User();
                        user.Name = reader["Имя"].ToString();
                        user.LastName = reader["Фамилия"].ToString();
                        user.FatherName = reader["Отчество"].ToString();
                        user.Login = reader["Логин"].ToString();
                        user.Telephone = reader["Телефон"].ToString();
                        user.Password = reader["Пароль"].ToString();
                        user.Email = reader["E-mail"].ToString();

                        users.Add(user);
                    }

                    reader.Close();
                    connection.Close();
                }

                return users;
            }
        }
    }
}
