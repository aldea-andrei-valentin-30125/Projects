using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class FavoriteRestaurant
    {
        public int Id { get; set; }
        public int CliendId { get; set; }
        public int RestaurantId { get; set; }
    }
}