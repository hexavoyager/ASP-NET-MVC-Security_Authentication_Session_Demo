using BxlForm.DemoSecurity.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Client.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User entity);
        bool EmailExists(string email);
    }
}
