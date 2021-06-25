using BxlForm.DemoSecurity.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Client.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get(int userId);
        IEnumerable<Contact> GetByCategory(int catId);
        Contact Get(int userId, int id);
        void Insert(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int userId, int id);
    }
}
