using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    public class Solider:Person
    {
        int rank;
        //List<Weapons>;
        public Solider(string First_name, string Last_name, int age, int rank) : base(First_name, Last_name, age) {
            this.rank = rank;

        }

        public int Get_Rank()
        {
            return rank;
        }

        public void show_Solider()
        {
            Console.WriteLine($"Solider Name: {Firstname} {Lastname}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Rank: {rank}");
        }

    }
}
