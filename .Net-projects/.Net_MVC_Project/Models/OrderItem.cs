using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }

    }
}