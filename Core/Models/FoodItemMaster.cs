using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class FoodItemMaster
    {
        public FoodItemMaster()
        {
            OrderItem = new HashSet<OrderItem>();
            OrderMaster = new HashSet<OrderMaster>();
            RatingMaster = new HashSet<RatingMaster>();
        }

        public int FoodItemId { get; set; }
        public int FoodCatId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string Image { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public FoodCategoryMaster FoodCat { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
        public ICollection<OrderMaster> OrderMaster { get; set; }
        public ICollection<RatingMaster> RatingMaster { get; set; }
    }
}
