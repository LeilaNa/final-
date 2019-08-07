using Evimiz.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evimiz.ViewModel
{
    public class NavBarViewModel
    {
        public ICollection<Category> Category { get; set; }
        public ICollection<SubCategory> SubCategory { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}