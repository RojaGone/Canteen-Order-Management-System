using System;
using System.Collections.Generic;

namespace canteen_management_system.Models
{
    public partial class SpecialityMaster
    {
        public int SpecialityId { get; set; }
        public int UserId { get; set; }
        public int FoodCatId { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public bool IsApproed { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public FoodCategoryMaster FoodCat { get; set; }
        public UserMaster User { get; set; }
    }
}
