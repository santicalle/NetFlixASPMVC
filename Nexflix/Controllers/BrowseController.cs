using Nexflix.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexflix.Controllers
{
    public class BrowseController : Controller
    {
        private BrowseRepository _repo;

        public BrowseController()
        {
            _repo = new BrowseRepository();
        }
        
        // GET: Browse
        public ActionResult ShowCategories()
        {
            var model = _repo.GetAllCategories();
            return View(model);
        }

        public ActionResult GetMoviesByCategory(int id)
        {

            var model = _repo.GetMoviesById(id);
            return View(model);
        }
    }
}