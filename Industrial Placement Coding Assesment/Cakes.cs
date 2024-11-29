using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial_Placement_Coding_Assesment
{
    internal class Cakes:Beverage //making the Cake inherit from the Beverage class in order to optimize the code
    {
       
        public Cakes(string name)
        {
            this.description = name;
            switch (name.ToLower())
            {
                case "muffins": this.cost = 2.03f; break;
                case "flapjacks": this.cost = 2.59f; break;
                case "panettone": this.cost = 2.88f; break;
               
                default: this.cost = 0f; break;
            }
        }

        
    }
}
