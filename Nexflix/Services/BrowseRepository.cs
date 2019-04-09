using Nexflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nexflix.Services
{
    public class BrowseRepository
    {

        public List<Category> GetAllCategories()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Categories.ToList();
            }
        }

        internal object GetMoviesById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return (from movies in db.Movies
                        where movies.CategoryId == id
                        select movies).ToList();
            }
        }
    }
}