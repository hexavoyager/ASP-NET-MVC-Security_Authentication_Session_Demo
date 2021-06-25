using BxlForm.DemoSecurity.Infrastructure.Security;
using BxlForm.DemoSecurity.Infrastructure.Session;
using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using BxlForm.DemoSecurity.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Controllers
{
    [AuthRequired]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISessionManager _sessionManager;

        public ContactController(IContactRepository contactRepository, ICategoryRepository categoryRepository, ISessionManager sessionManager)
        {
            _contactRepository = contactRepository;
            _categoryRepository = categoryRepository;
            _sessionManager = sessionManager;
        }

        // GET: ContactController
        public IActionResult Index()
        {
            return View(_contactRepository.Get(_sessionManager.User.Id).Select(c => new DisplayContact() { Id = c.Id, LastName = c.LastName, FirstName = c.FirstName }));
        }

        public IActionResult Details(int id)
        {
            Contact contact = _contactRepository.Get(_sessionManager.User.Id, id);

            if(contact is null)
                return RedirectToAction("Index");

            return View(new DisplayDetailsContact() { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName, Email = contact.Email, CategoryId = contact.CategoryId });
        }

        public IActionResult Create()
        {
            CreateContactForm form = new CreateContactForm();
            form.Categories = GetCategories();

            return View(form);
        }

        [HttpPost]
        public IActionResult Create(CreateContactForm form)
        {
            if (!ModelState.IsValid)
            {
                form.Categories = GetCategories(form.CategoryId);
                return View(form);
            }

            Contact newContact = new Contact(form.LastName, form.FirstName, form.Email, form.CategoryId, _sessionManager.User.Id);

            _contactRepository.Insert(newContact);
            return RedirectToAction("Index");
        }        

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            Contact contact = _contactRepository.Get(_sessionManager.User.Id, id);

            if (contact is null)
                return RedirectToAction("Index");

            EditContactForm form = new EditContactForm()
            {
                Id = contact.Id,
                LastName = contact.LastName,
                FirstName = contact.FirstName,
                Email = contact.Email,
                CategoryId = contact.CategoryId,
                Categories = GetCategories(contact.CategoryId)
            };

            return View(form);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditContactForm form)
        {
            if (!ModelState.IsValid)
            {
                form.Categories = GetCategories(form.CategoryId);
                return View(form);
            }

            _contactRepository.Update(id, new Contact(form.LastName, form.FirstName, form.Email, form.CategoryId, _sessionManager.User.Id));

            return RedirectToAction("Index");
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contact = _contactRepository.Get(_sessionManager.User.Id,id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(new DisplayDetailsContact() { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName, Email = contact.Email, CategoryId = contact.CategoryId });
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _contactRepository.Delete(_sessionManager.User.Id, id);

            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GetCategories(int? id = null)
        {
            return _categoryRepository.Get().Select(c => new SelectListItem(c.Name, c.Id.ToString()) { Selected = (id.HasValue && c.Id == id.Value) });
        }
    }
}
