using System;
using System.Collections.Generic;
using Project_idf___;

namespace Project_idf___
{
    internal class M109_Artillery : Attack_options
    {
        public M109_Artillery( string uniqueName, int ammunitionCapacity,int fuelSupply,string operated_by) : base(uniqueName, 40, fuelSupply , operated_by)
        {
            bomb_type = new Dictionary<string, int>
            {
                { "explosive shells", ammunitionCapacity }
            };

            Effective_target.Add(typeof(Open_Areas));
        }
    
    
    }
}
