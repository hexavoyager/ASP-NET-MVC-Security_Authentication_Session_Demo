using BxlForm.DemoSecurity.Models.Global.Data;
using System.Collections.Generic;

namespace BxlForm.DemoSecurity.Models.Global.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        void Insert(Category c);
        void Update(int id, Category cat);
        void Delete(int id);
    }
}
