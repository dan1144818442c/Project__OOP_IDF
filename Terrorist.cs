using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    internal class Terrorist : Person
    {
        int rank;
        string status;
        List<Weapons> weapons;
        Dictionary<string, string> location;

        Dictionary<string, string> data = new Dictionary<string, string>();
        string Last_location;
        public Terrorist(string First_name, string Last_name, int age, int rank) : base(First_name, Last_name, age)
        {
            if (rank < 0) rank = 0;
            if (rank > 5) rank = 5;
            this.rank = rank;
            status = "alive";
            weapons = new List<Weapons>();
            Last_location = null;
            location = new Dictionary<string, string>();

        }
        public string Get_Last_Location()
        {
            return Last_location;
        }

        string Get_Status()
        {
            return status;
        }
        public int Get_Rank()
        {
            return rank;
        }

        public void updat_loction(string location, Solider solider)
        {
            if (solider.Get_Rank() > 3)
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
