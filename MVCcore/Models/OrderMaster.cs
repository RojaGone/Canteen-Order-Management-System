using System;
using System.Collections.Generic;

namespace canteen_management_system.Models
{
    public partial class OrderMaster
    {
        public OrderMaster()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderMasterId { get; set; }
        public int UserId { get; set; }
        public TimeSpan OrderDeliverytime { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public OrderMaster OrderMasterNavigation { get; set; }
        public UserMaster User { get; set; }
        public OrderMaster InverseOrderMasterNavigation { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
