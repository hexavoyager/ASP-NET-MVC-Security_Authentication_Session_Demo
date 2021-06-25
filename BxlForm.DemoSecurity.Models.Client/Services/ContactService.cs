using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Mappers;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using GR = BxlForm.DemoSecurity.Models.Global.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BxlForm.DemoSecurity.Models.Client.Services
{
    public class ContactService : IContactRepository
    {
        private readonly GR.IContactRepository _globalRepository;

        public ContactService(GR.IContactRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }        

        public IEnumerable<Contact> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(c => c.ToClient());
        }

        public IEnumerable<Contact> GetByCategory(int catId)
        {
            return _globalRepository.GetByCategory(catId).Select(c => c.ToClient());
        }

        public Contact Get(int userId, int id)
        {
            return _globalRepository.Get(userId, id)?.ToClient();
        }

        public void Insert(Contact contact)
        {
            _globalRepository.Insert(contact.ToGlobal());
        }

        public void Update(int id, Contact contact)
        {
            _globalRepository.Update(id, contact.ToGlobal());
        }

        public void Delete(int userId, int id)
        {
            _globalRepository.Delete(userId, id);
        }
    }
}
