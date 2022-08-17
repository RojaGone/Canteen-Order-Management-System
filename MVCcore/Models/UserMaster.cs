using System;
using System.Collections.Generic;

namespace canteen_management_system.Models
{
    public partial class UserMaster
    {
        public UserMaster()
        {
            ChefCollectOrderMaster = new HashSet<ChefCollectOrderMaster>();
            FeedbackMaster = new HashSet<FeedbackMaster>();
            OrderMaster = new HashSet<OrderMaster>();
            SpecialityMaster = new HashSet<SpecialityMaster>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PhoneNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Pincode { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int UserType { get; set; }

        public ICollection<ChefCollectOrderMaster> ChefCollectOrderMaster { get; set; }
        public ICollection<FeedbackMaster> FeedbackMaster { get; set; }
        public ICollection<OrderMaster> OrderMaster { get; set; }
        public ICollection<SpecialityMaster> SpecialityMaster { get; set; }
    }
}
