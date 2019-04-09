using Nexflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nexflix.Services
{
    public class MovieRepository
    {
        public List<Movie> GetAllMovies()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Movies.Include("Category").ToList();
            }
        }

        internal void CreateMovie(Movie model)
        {
            using(var db = new ApplicationDbContext())
            {
                db.Movies.Add(model);
                db.SaveChanges();
            }
        }

        internal object GetMovieById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var movie = (from m in db.Movies
                             where m.Id == id
                             select m).FirstOrDefault();

                var _cRepo = new CategoryRepository();
                movie.Categories = _cRepo.GetListCategories();

                return movie;
            }
        }

        internal object GetMovieById_API(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var movie = (from m in db.Movies.Include("Category")
                             where m.Id == id
                             select m).FirstOrDefault();

                return movie;
            }
        }

        internal void UpdateMovie(int id, Movie model)
        {
            using (var db = new ApplicationDbContext())
            {
                Movie movieEdit = (from m in db.Movies
                             where m.Id == id
                             select m).FirstOrDefault();

                movieEdit.Title = model.Title;
                movieEdit.Description = model.Description;
                movieEdit.CategoryId = model.CategoryId;
                db.SaveChanges();
            }                
        }
    }
}