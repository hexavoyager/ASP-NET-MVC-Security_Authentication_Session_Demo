using BxlForm.DemoSecurity.Models.Global.Data;
using BxlForm.DemoSecurity.Models.Global.Mappers;
using BxlForm.DemoSecurity.Models.Global.Repositories;
using System.Collections.Generic;
using System.Linq;
using Tools.Connections.Database;

namespace BxlForm.DemoSecurity.Models.Global.Services
{
    public class ContactService : IContactRepository
    {
        private readonly Connection _connection;

        public ContactService(Connection connection)
        {
            _connection = connection;
        }      

        public IEnumerable<Contact> Get(int userId)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, CategoryId, UserId From Contact Where UserId = @UserId;", false);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int userId, int id)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, CategoryId, UserId From Contact Where Id = @Id and UserId = @UserId;", false);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

        public IEnumerable<Contact> GetByCategory(int catId)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, CategoryId, UserId From Contact Where CategoryId = @CategoryId;", false);
            command.AddParameter("CategoryId", catId);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public void Insert(Contact contact)
        {
            Command command = new Command("BFSP_AddContact", true);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, Contact contact)
        {
            Command command = new Command("BFSP_UdpateContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int userId, int id)
        {
            Command command = new Command("BFSP_DeleteContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            _connection.ExecuteNonQuery(command);
        }
    }
}
