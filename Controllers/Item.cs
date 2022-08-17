using canteen_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace canteen_management_system.Controllers
{
    public class Item
    {
        private food_item_master Food_Item_Master = new food_item_master();

        public food_item_master Food_Item_Masters
        {
            get { return Food_Item_Master; }
            set { Food_Item_Master = value; }
        }

        private order_master order_Master = new order_master();

        public order_master order_Masters
        {
            get { return order_Master; }
            set { order_Master = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item()
        {

        }

        public Item(food_item_master Food_Item_Master, int quantity)
        {
            this.Food_Item_Master = Food_Item_Master;
            this.quantity = quantity;
        }
    }
}