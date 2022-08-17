using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class PaymentMaster
    {
        public int PaymentId { get; set; }
        public int OrderItemId { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public OrderItem OrderItem { get; set; }
    }
}
