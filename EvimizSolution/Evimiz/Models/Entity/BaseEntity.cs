using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evimiz.Models.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [EvimizDatabaseGenerated(DatabaseGeneratedOption.Computed, DefaultValueSql = "getdate()")]
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        
        [ScaffoldColumn(false)]
        public DateTime? DeletedDate { get; set; }

        [ScaffoldColumn(false)]
        public int? DeletedId { get; set; }
    }
}