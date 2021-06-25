using BxlForm.DemoSecurity.Areas.Admin.Models.Forms.Category;
using BxlForm.DemoSecurity.Infrastructure.Security;
using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AdminRequired]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContactRepository _contactRepo;

        public CategoryController(ICategoryRepository categoryRepository, IContactRepository contactRepo)
        {
            _categoryRepository = categoryRepository;
            _contactRepo = contactRepo;
        }

        public ActionResult Index()
        {
            return View(_categoryRepository.Get().Select(c => new DisplayCategory() { Id = c.Id, Name = c.Name, CanDelete = _contactRepo.GetByCategory(c.Id).Count() == 0}));
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            _categoryRepository.Insert(new Category(form.Name));

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCategoryForm f)
        {
            if (!ModelState.IsValid)
            {
                return View(f);
            }
            _categoryRepository.Update(id, new Category(f.Name));

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (_contactRepo.GetByCategory(id).Count() == 0)
            {
                _categoryRepository.Delete(id);
            }
            

            return RedirectToAction("Index");
        }
    }
}
