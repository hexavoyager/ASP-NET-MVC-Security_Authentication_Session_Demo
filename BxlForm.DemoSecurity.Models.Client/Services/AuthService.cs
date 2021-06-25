using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using GR = BxlForm.DemoSecurity.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using BxlForm.DemoSecurity.Models.Client.Mappers;

namespace BxlForm.DemoSecurity.Models.Client.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly GR.IAuthRepository _globalRepository;

        public AuthService(GR.IAuthRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public bool EmailExists(string email)
        {
            return _globalRepository.EmailExists(email);
        }

        public User Login(string email, string passwd)
        {
            return _globalRepository.Login(email, passwd)?.ToClient();
        }

        public void Register(User entity)
        {
            _globalRepository.Register(entity.ToGlobal());
        }
    }
}
