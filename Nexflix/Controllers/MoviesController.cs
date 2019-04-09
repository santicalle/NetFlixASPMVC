using Nexflix.Models;
using Nexflix.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexflix.Controllers
{
    public class MoviesController : Controller
    {
        private MovieRepository _repo;
        private CategoryRepository _cRepo;

        public MoviesController()
        {
            _repo = new MovieRepository();
        }

        [HttpGet]
        public JsonResult GetMovieById(int id)
        {

            return Json(new { data = _repo.GetMovieById_API(id) }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult SaveMovie(Movie movie)
        //{

        //}

        // GET: BlogPost
        public ActionResult Index()
        {
            var model = _repo.GetAllMovies();
            return View(model);
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            _cRepo = new CategoryRepository();
            var model = new Movie()
            {
                Categories = _cRepo.GetListCategories()
            };
            return View(model);
        }

        // POST: BlogPost/Create
        [HttpPost]
        public ActionResult Create(Movie model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.CreateMovie(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // log
            }

            return View(model);
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _repo.GetMovieById(id);            
            return View(model);
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie model)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    _repo.UpdateMovie(id, model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log
            }

            return View(id);
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
