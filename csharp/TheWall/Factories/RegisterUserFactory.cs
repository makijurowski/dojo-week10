using Dapper;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LoginRegistration.Factory
{
    public class RegisterUserFactory : IFactory<RegisterUser>
    {
        private string connectionString;
        
        public RegisterUserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }

        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(RegisterUser item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                item.Password = hasher.HashPassword(item, item.Password);
                string query = "INSERT INTO Users (first_name, last_name, email, password, created_at, updated_at) VALUES(@First_Name, @Last_Name, @Email, @Password, NOW(), NOW()); SELECT LAST_INSERT_ID() as id";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }

        public IEnumerable<RegisterUser> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RegisterUser>("SELECT * FROM users");
            }
        }

        public RegisterUser FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RegisterUser>("SELECT * FROM users WHERE id = @id", new { Id = id }).FirstOrDefault();
            }
        }

        public RegisterUser FindByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RegisterUser>("SELECT * FROM users WHERE email = @email", new { Email = email }).FirstOrDefault();
            }
        }
    }
}