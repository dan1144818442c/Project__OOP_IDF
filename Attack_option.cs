using System;
using System.Collections.Generic;
using Project_idf___;

namespace Project_idf___
{
    abstract class Attack_options
    {
        protected string aunique_name;
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

        public void Attack(Target target)
        {
            if (Effective_target.Contains(target.GetType()))
            {
                Console.WriteLine("writename of wich bomp you want use:");
                foreach (var bomb in bomb_type)
                {
                    Console.WriteLine(bomb.Key + ": " + bomb.Value);
                }
                String type_bomb = Console.ReadLine();
                if (bomb_type[type_bomb] > 0)
                {
                    bomb_type[type_bomb]--;
                }
                else
                {
                    Console.WriteLine("you dont have this bomb");
                }

                Console.WriteLine("Attacking " + target.GetType().Name);
                target.Destroy();
                // Implement attack logic here
            }
            else
            {
                Console.WriteLine("Target not effective for this weapon.");
            }
        }
    }
}
