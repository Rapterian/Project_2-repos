using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodRestaurantMenu
{
    //puting all the connected data in one product makes it
    //easier to retrieve specific data out of a list
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
