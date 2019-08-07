using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evimiz.Models.Entity
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage = "Bu sahə boş buraxıla bilməz")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}