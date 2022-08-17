using System;
using System.Collections.Generic;

namespace canteen_management_system.Models
{
    public partial class ChefCollectOrderMaster
    {
        public int ChefCollectOrderId { get; set; }
        public int UserId { get; set; }
        public bool IsStart { get; set; }
        public bool IsDone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime UpdateDatetime { get; set; }

        public UserMaster User { get; set; }
    }
}
