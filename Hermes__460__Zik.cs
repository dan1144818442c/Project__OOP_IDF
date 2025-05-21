using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_idf___;

namespace Project_idf___
{
    internal class Hermes__460__Zik__ : Attack_options
    {

        public Hermes__460__Zik__(string uniqueName, int ammunitionCapacity, int fuelSupply, string operated_by) : base(uniqueName, 3, fuelSupply, operated_by)
        {
            bomb_type = new Dictionary<string, int>
            {
                { "peopels ", ammunitionCapacity -1  },
                { "cars ", 1 } };
            Effective_target.Add(typeof(Terrorist));
            Effective_target.Add(typeof(Armored_vehicles) );

        }

    }


}