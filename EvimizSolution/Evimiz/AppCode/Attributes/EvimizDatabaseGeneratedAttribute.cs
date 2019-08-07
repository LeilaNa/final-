using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evimiz
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EvimizDatabaseGeneratedAttribute:DatabaseGeneratedAttribute
    {
        public string DefaultValueSql { get; set; }
        public EvimizDatabaseGeneratedAttribute(DatabaseGeneratedOption databaseGeneratedOption)
            : base(databaseGeneratedOption)
        {

        }
    }
}