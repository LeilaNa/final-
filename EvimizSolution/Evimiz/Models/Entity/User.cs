using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evimiz.Models.Entity
{
    public enum Gender
    {
        Female,
        Male
    }
    public class User:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }


        [Required(ErrorMessage ="Bu sahə boş buraxıla bilməz")]
        [MaxLength(50)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu sahə boş buraxıla bilməz")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(150)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Bu sahə boş buraxıla bilməz")]
        [MaxLength(250)]
        public string Password { get; set; }

        public  Gender Gender { get; set; }

    }
}