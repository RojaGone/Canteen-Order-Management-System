using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace canteen_management_system.Models
{
    public class Class1
    {
        public int food_cat_id { get; set; }
        public string food_cat_name { get; set; }
        public System.DateTime create_datetime { get; set; }
        public System.DateTime update_datetime { get; set; }
        public bool is_active { get; set; }
        public bool is_delete { get; set; }
    }
}