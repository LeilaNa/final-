using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evimiz.Models.Entity
{
    public class Product:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double? SaledPrice { get; set; }
        public string Description { get; set; }
        [Required]
        public string PhotoPath1 { get; set; }
        public string PhotoPath2 { get; set; }
        public string PhotoPath3 { get; set; }
        public string PhotoPath4 { get; set; }
        public string PhotoPath5 { get; set; }
    }
}