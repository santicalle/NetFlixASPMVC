using Nexflix.Models;
using Nexflix.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexflix.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryRepository _repo;

        public CategoriesController()
        {
            _repo = new CategoryRepository();
        }

        // GET: Categories
        public ActionResult Index()
        {
            var model = _repo.GetAllCategories();
            return View(model);
        }

        public JsonResult GetAllCategories()
        {
            return Json(_repo.GetAllCategories(), JsonRequestBehavior.AllowGet);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Category model = _repo.GetCategoryById(id);
            return View(model);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Categorias";
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.CreateCategory(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // log
            }

            return View(model);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            Category model = _repo.GetCategoryById(id);
            return View(model);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category model)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    _repo.UpdateCategory(id, model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log
            }

            return View(id);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            Category model = _repo.GetCategoryById(id);
            return View(model);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category model)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.DeleteCategory(id);
                return RedirectToAction("Index");

            }
            catch
            {
                
            }
            return View();
        }
    }
}
