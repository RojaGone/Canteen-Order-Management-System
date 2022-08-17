using System;
using System.Collections.Generic;

namespace canteen_management_system.Models
{
    public partial class RatingMaster
    {
        public int RatingId { get; set; }
        public int FoodItemId { get; set; }
        public int? Rating { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public FoodItemMaster FoodItem { get; set; }
    }
}
