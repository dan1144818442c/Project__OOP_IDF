using System;
using System.Collections.Generic;
using Project_idf___;

namespace Project__Analiza
{
    abstract class Attack_options
    {
        protected string aunique_name;
        protected int Ammunition_capacity;
        protected int Fuel_supply;
        protected List<Type> Effective_target;
        protected Dictionary<string, int> bomb_type = new Dictionary<string, int>();
        protected string operated_by ;
        public Attack_options(string aunique_name, int Ammunition_capacity, int Fuel_supply , string operated_by)
        {
            this.aunique_name = aunique_name;
            this.Ammunition_capacity = Ammunition_capacity;
            this.Fuel_supply = Fuel_supply;
            this.operated_by = operated_by;
        }

        public void Add_bomb_type(string bomb, int Ammunition_capacity)
        {
            if (bomb_type.ContainsKey(bomb))
            {
                bomb_type[bomb] += Ammunition_capacity;
            }
            else
            {
                Console.WriteLine("dont have this type bomb");
            }
        }
    }
