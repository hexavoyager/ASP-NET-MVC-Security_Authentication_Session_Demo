using BxlForm.DemoSecurity.Models.Global.Data;
using BxlForm.DemoSecurity.Models.Global.Mappers;
using BxlForm.DemoSecurity.Models.Global.Repositories;
using System.Linq;
using Tools.Connections.Database;

namespace BxlForm.DemoSecurity.Models.Global.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly Connection _connection;

        public AuthService(Connection connection)
        {
            _connection = connection;
        }

        public bool EmailExists(string email)
        {
            Command command = new Command("Select Count(*) From [User] where Email = @Email;", false);
            command.AddParameter("Email", email);

            int count = (int)_connection.ExecuteScalar(command);
            return count == 1;
        }

        public User Login(string email, string passwd)
        {
            Command command = new Command("BFSP_AuthUser", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public void Register(User entity)
        {
            Command command = new Command("BFSP_RegisterUser", true);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Passwd", entity.Passwd);
            _connection.ExecuteNonQuery(command);
            entity.Passwd = null;
        }
    }
}
