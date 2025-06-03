using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    public class Terrorist : Person
    {
        int rank;
        string status;
        int RiskLevel;
        List<Weapons> weapons;
        public Dictionary<string, Target> location { get; set; }
        Dictionary<string, string> data = new Dictionary<string, string>();
        public Target Last_location {get; set; }
        public Terrorist(string First_name, string Last_name, int age, int rank) : base(First_name, Last_name, age)
        {
            if (rank < 0) rank = 0;
            if (rank > 5) rank = 5;
            this.rank = rank;
            status = "alive";
            weapons = new List<Weapons>();
            Last_location = null;
            RiskLevel = weaponslevel();
            location = new Dictionary<string, Target>();

        }
       

        public string Get_Status()
        {
            return status;
        }
        public int Get_Rank()
        {
            return rank;
        }


      
        public int weaponslevel()
        {
            Dictionary<Type, int> weapon = new Dictionary<Type, int>() { { typeof(knife), 1 }, { typeof(Gun), 2 }, { typeof(Rifle_M16), 3 }, { typeof(Rifle_AK47), 3 } };

            int level = 0;
            foreach (var itam in weapons)
            {
                if (weapon.TryGetValue(itam.GetType(), out int score))
                {
                    level += score;
                }

            }
            if (level == 0)
            {
                RiskLevel = rank;
                return RiskLevel;

            }
            if (rank<=0) {
                RiskLevel = level;
                return RiskLevel;
            }
            RiskLevel = level * rank;
            return RiskLevel;



        }

        public void attack()
        {
            this.status = "dead";
        }
        public void add_weapend(Weapons weapon)
        {

            this.weapons.Add(weapon);
            RiskLevel = weaponslevel();

        }
        public List<Weapons> Get_Weapons()
        {

            return weapons;
        }

        public Dictionary<string, object> GEt_data_Terorist()
        {
            var data = new Dictionary<string, object>
            {
                { "Firstname", this.Firstname },
                { "Lastname", this.Lastname },
                { "Age", this.age },
                { "Rank", this.rank },
                { "Status", this.status },
                { "RiskLevel", this.RiskLevel },
                { "Weapons", ( this.weapons) },
                { "Location", this.location },
                { "LastLocation", this.Last_location }
            };
            return data;
        }

        public void show_data_terorist()
        {
            Console.WriteLine("---------------------------");
            foreach (var item in GEt_data_Terorist())
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine("---------------------------");

        }










    }
}
