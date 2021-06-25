using BxlForm.DemoSecurity.Models.Global.Data;
using BxlForm.DemoSecurity.Models.Global.Mappers;
using BxlForm.DemoSecurity.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Connections.Database;

namespace BxlForm.DemoSecurity.Models.Global.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly Connection _connection;

        public CategoryService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("Select Id, Name From Category;", false);
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public void Insert(Category c)
        {
            Command command = new Command("BFSP_AddCategory", true);
            command.AddParameter("name", c.Name);
            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, Category cat)
        {
            Command cmd = new Command("UPDATE [Category] SET Name = @Name WHERE Id = @Id;", false);
            cmd.AddParameter("Name", cat.Name);
            cmd.AddParameter("Id", id);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Delete(int id)
        {
            Command cmd = new Command("BSFP_DeleteCategory", true);
            cmd.AddParameter("Id", id);
            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Contact> GetByCategory(int catId)
        {
            Command command = new Command("Select Id, LastName, FirstName, Email, CategoryId, UserId From Contact Where CategoryId = @CategoryId;", false);
            command.AddParameter("CategoryId", catId);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }
    }
}
