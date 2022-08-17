using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace canteen_management_system.Models
{
    public class CanteenModel
    {

        public int user_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string e_mail { get; set; }
        public string phone_no { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Nullable<int> pincode { get; set; }
        public Nullable<System.DateTime> create_datetime { get; set; }
        public Nullable<System.DateTime> update_datetime { get; set; }
        public Nullable<bool> is_active { get; set; }
        public Nullable<bool> is_delete { get; set; }
        public Nullable<int> user_type { get; set; }

    }
}