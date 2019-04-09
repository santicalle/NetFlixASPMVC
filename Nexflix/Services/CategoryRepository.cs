using Nexflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexflix.Services
{
    public class CategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using ( var db = new ApplicationDbContext() )
            {
                return db.Categories.ToList();
            }
        }

        internal void CreateCategory(Category model)
        {
            using (var db = new ApplicationDbContext())
            {

                db.Categories.Add(model);
                db.SaveChanges();

            }
        }

        internal Category GetCategoryById(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext() )
            {
                return (from category in db.Categories
                       where category.Id == id
                       select category).FirstOrDefault();
            }
        }

        internal void UpdateCategory(int id, Category model)
        {
            using( var db = new ApplicationDbContext())
            {
                // Category modelEdit = GetCategoryById(id);

                Category modelEdit = (from category in db.Categories
                                      where category.Id == id
                                      select category).FirstOrDefault();

                modelEdit.Name = model.Name;
                db.SaveChanges();
            }
        }

        internal void DeleteCategory(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Category modelDelete = (from category in db.Categories
                                      where category.Id == id
                                      select category).FirstOrDefault();

                db.Categories.Remove(modelDelete);
                db.SaveChanges();
            }                
        }

        public IEnumerable<SelectListItem> GetListCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> categories = context.Categories.AsNoTracking()
                        .OrderBy(n => n.Name)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToList();

                var countrytip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select category ---"
                };
                categories.Insert(0, countrytip);
                return new SelectList(categories, "Value", "Text");
            }
        }
    }
}