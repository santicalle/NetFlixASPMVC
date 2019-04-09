using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nexflix.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int Ranking { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { set; get; }
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}