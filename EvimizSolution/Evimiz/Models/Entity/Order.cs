using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evimiz.Models.Entity
{
    public enum Status{
        IsRecieved,
        IsOrdered,
        IsCanceled
    }
    public class Order:BaseEntity
    {
        public virtual User UserId { get; set; }
        public virtual Product ProductId { get; set; }
        public Status Status { get; set; }
    }
}