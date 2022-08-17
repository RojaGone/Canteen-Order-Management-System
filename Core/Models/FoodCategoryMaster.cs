using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class FoodCategoryMaster
    {
        public FoodCategoryMaster()
        {
            FoodItemMaster = new HashSet<FoodItemMaster>();
            SpecialityMaster = new HashSet<SpecialityMaster>();
        }

        public int FoodCatId { get; set; }
        public string FoodCatName { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public ICollection<FoodItemMaster> FoodItemMaster { get; set; }
        public ICollection<SpecialityMaster> SpecialityMaster { get; set; }
    }
}
