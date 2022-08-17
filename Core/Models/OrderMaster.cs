using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class OrderMaster
    {
        public OrderMaster()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderMasterId { get; set; }
        public int UserId { get; set; }
        public int? FoodItemId { get; set; }
        public double? TotalPrice { get; set; }
        public int? Quantity { get; set; }
        public TimeSpan OrderDeliverytime { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public FoodItemMaster FoodItem { get; set; }
        public UserMaster User { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
