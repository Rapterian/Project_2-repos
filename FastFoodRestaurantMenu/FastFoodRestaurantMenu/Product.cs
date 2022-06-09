using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodRestaurantMenu
{
    internal class Product
    {
        public string productName { get; set; }
        public double productPrice { get; set; }
        public Product(string productName, double productPrice)
        {
            this.productName = productName;
            this.productPrice = productPrice;
        }
    }
}
