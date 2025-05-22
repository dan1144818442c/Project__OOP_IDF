using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_idf___;

namespace Project_idf___
{
    internal class F16_Fighter_Jet : Attack_options
    {
        
        public F16_Fighter_Jet(string uniqueName, int ammunitionCapacity, int fuelSupply, string operated_by) : base(uniqueName, 8, fuelSupply, operated_by)
        {
            bomb_type["0.5 ton"] = 2;
            bomb_type["1 ton"] = 1;

            Effective_target.Add(typeof(Building));

        }




    }


}