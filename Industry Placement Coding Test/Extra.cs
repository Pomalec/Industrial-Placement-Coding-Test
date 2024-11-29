using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry_Placement_Coding_Test
{
    internal class Extra : Beverage//making the Cake inherit from the Beverage class in order to optimize the code
    {

        public Extra(string name)
        {
            this.description = name;
            switch (name.ToLower())
            {
                case "milk": this.cost = 0.53f; break;
                case "sugar": this.cost = 0.17f; break;
                case "cream": this.cost = 0.73f; break;
                case "sprinkles": this.cost = 0.29f; break;
                default: this.cost = 0f; break;
            }
        }

    }
}
