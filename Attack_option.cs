using System;
using System.Collections.Generic;
using Project_idf___;

namespace Project_idf___
{
    abstract public class Attack_options
    {
        protected string aunique_name { get; set; }
        protected int Ammunition_capacity;
        protected int Fuel_supply;
        protected List<Type> Effective_target;
        protected Dictionary<string, int> bomb_type = new Dictionary<string, int>();
        protected string operated_by;
        public Attack_options(string aunique_name, int Ammunition_capacity, int Fuel_supply, string operated_by)
        {
            this.aunique_name = aunique_name;
            this.Ammunition_capacity = Ammunition_capacity;
            this.Fuel_supply = Fuel_supply;
            this.operated_by = operated_by;
            this.Effective_target = new List<Type>();
            this.bomb_type = new Dictionary<string, int>();
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

        public void show_Weapon()
        {
            Console.WriteLine("Weapon name: " + aunique_name);
            Console.WriteLine("Fuel supply: " + Fuel_supply);
            Console.WriteLine("Operated by: " + operated_by);
            Console.WriteLine("Effective targets: ");
            foreach (var target in Effective_target)
            {
                Console.WriteLine(target.Name);
            }
            Console.WriteLine("Bomb types and their quantities:");
            foreach (var bomb in bomb_type)
            {
                Console.WriteLine(bomb.Key + ": " + bomb.Value);
            }
        }

        public void Attack(Terrorist terrorist, Target target = null)
        {
            string type_bomb;

            if (target == null || Effective_target.Contains(target.GetType()))
            {
                Console.WriteLine("Write the name of the bomb you want to use:");

                do
                {
                    foreach (var bomb in bomb_type)
                    {
                        Console.WriteLine(bomb.Key + ": " + bomb.Value);
                    }

                    type_bomb = Console.ReadLine();
                }
                while (!bomb_type.ContainsKey(type_bomb));

                if (bomb_type[type_bomb] > 0)
                {
                    bomb_type[type_bomb]--;

                    if (target != null)
                    {
                        Console.WriteLine("Attacking target: " + target.GetType().Name);
                        target.Destroy();
                        terrorist.attack();
                    }
                    else
                    {
                        Console.WriteLine("Attacking terrorist without specific target.");
                        terrorist.attack();

                    }

                }
                else
                {
                    Console.WriteLine("You don't have this bomb.");
                }
            }
            else
            {
                Console.WriteLine("Target not effective for this weapon.");
            }
        }
        public string AuniqueName
        {
            get { return aunique_name; }
        }


    }
}
