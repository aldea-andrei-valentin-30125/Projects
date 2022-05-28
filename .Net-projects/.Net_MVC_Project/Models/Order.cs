using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CliendId { get; set; }
        public int? DeliveryId { get; set; }
        public int CartId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public EnumStatus Status { get; set; }

    }

    public enum EnumStatus
    {
        Trimis,
        Acceptat,
        Livrat
    }
}