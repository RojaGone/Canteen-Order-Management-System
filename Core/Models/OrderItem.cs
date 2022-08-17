using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            PaymentMaster = new HashSet<PaymentMaster>();
        }

        public int OrderItemId { get; set; }
        public int OrderMasterId { get; set; }
        public int FoodItemId { get; set; }
        public double TotalPrice { get; set; }
        public int Status { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public FoodItemMaster FoodItem { get; set; }
        public OrderMaster OrderMaster { get; set; }
        public ICollection<PaymentMaster> PaymentMaster { get; set; }
    }
}
