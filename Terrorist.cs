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
        Dictionary<string, Target> location;

        Dictionary<string, string> data = new Dictionary<string, string>();
        Target  Last_location;
        public Terrorist(string First_name, string Last_name, int age, int rank) : base(First_name, Last_name, age)
        {
            if (rank < 0) rank = 0;
            if (rank > 5) rank = 5;
            this.rank = rank;
            status = "alive";
            weapons = new List<Weapons>();
            Last_location = null;

            
            location = new Dictionary<string, Target>();

        }
        public Target Get_Last_Location()
        {
            return Last_location;
        }

       public string Get_Status()
        {
            return status;
        }
        public int Get_Rank()
        {
            return rank;
        }

        public void updat_loction(Target location, Solider solider)
        {
            if (solider.Get_Rank() < 3)
            {
                Console.WriteLine("Your rank isn't high enough");
            }
            else
            {
                Last_location = location;
                string current_time =  DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                this.location[current_time] = location;
            }
        }
        public int weaponslevel()
        {
            Dictionary<Type, int> weapon = new Dictionary<Type, int>() { {typeof(knife), 1 }, { typeof(Gun), 2 },{ typeof(Rifle_M16) ,3},{typeof(Rifle_AK47),3} };
            
            int level = 0;
            foreach (var itam in weapons)
            {
                if (weapon.TryGetValue(itam.GetType(), out int score))
                {
                    level += score;
                }

            }
            RiskLevel= level * rank;
            return RiskLevel;



        }

        public void attack()
        {
            this.status = "dead";
        }
        public void add_weapend(Weapons weapon)
        {

            this.weapons.Add(weapon);

        }
        public List<Weapons> Get_Weapons()
        {
            return weapons;
        }

        public List<object> GEt_data_Terorist() {
           List<object>  list = new List<object>();
            list.Add(this.Firstname);
            list.Add(Lastname);
            list.Add(age);
            list.Add(rank);
            list.Add(status);
            list.Add(weapons);
            list.Add(location);
            list.Add(Last_location);
            return list;
        }











    }
}
