using BxlForm.DemoSecurity.Infrastructure.Security;
using BxlForm.DemoSecurity.Infrastructure.Session;
using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using BxlForm.DemoSecurity.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISessionManager _sessionManager;

        public AuthController(IAuthRepository authRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AnonymousRequired]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            User user = _authRepository.Login(form.Email, form.Passwd);

            if(user is null)
            {
                ModelState.AddModelError("", "Email ou mot de passe invalide!!!");
                return View(form);
            }

            _sessionManager.User = new UserSession() { Id = user.Id, LastName = user.LastName, FirstName = user.FirstName, IsAdmin = user.IsAdmin };           

            return RedirectToAction("Index", "Contact");
        }

        [AnonymousRequired]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Register(RegisterForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            _authRepository.Register(new User(form.LastName, form.FirstName, form.Email, form.Passwd));
            return RedirectToAction("Login");
        }

        [AuthRequired]
        public IActionResult Logout()
        {
            //en ASP .Net MVC Classic ==> Session.Abandon()
            _sessionManager.Clear();
            return RedirectToAction("Login");
        }
    }
}
