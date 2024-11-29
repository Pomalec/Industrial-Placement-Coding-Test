using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial_Placement_Coding_Assesment
{
     internal class Beverage
    {
        protected float cost;
        protected string description;
        public Beverage() { }
        public float getCost()//returns the cost of the beverage
        {
            return this.cost;
        }
        public string getDescription()//returns the description of the beverage
        {
            return this.description;
        }
    
    }

}
