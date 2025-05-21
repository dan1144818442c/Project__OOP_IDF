using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    internal class Program
    {


        static void Main(string[] args)
        {
            List<Terrorist> terrorists = GenerateRandomTerrorists(5);
            foreach (var terrorist in terrorists)
            {
                foreach (var item in terrorist.GEt_data_Terorist())
                {

                    Console.WriteLine(item);
                }

                    foreach (Weapons item2 in terrorist.Get_Weapons())
                    {
                        Console.WriteLine(item2);
                    }
                Console.WriteLine();
                Console.WriteLine();
            }

        }

        static List<Terrorist> GenerateRandomTerrorists(int count)
        {
            var rnd = new Random();
            string[] firstNames = { "achmad", "AboALik", "Josef", "Machmood", "Tariq" };
            string[] lastNames = { "Hassan", "Nassar", "Abu", "Farid", "Zidan" };
            List<Terrorist> result = new List<Terrorist>();

            for (int i = 0; i < count; i++)
            {
                string first = firstNames[rnd.Next(firstNames.Length)];
                string last = lastNames[rnd.Next(lastNames.Length)];
                int age = rnd.Next(20, 45);
                int rank = rnd.Next(0, 6);

                Terrorist t = new Terrorist(first, last, age, rank);

                int weaponCount = rnd.Next(1, 4);
                Type[] Type_WEaponds = { typeof(Rifle_AK47), typeof(Rifle_M16), typeof(Gun), typeof(knife) };
                for (int j = 0; j < weaponCount; j++)
                {
                    int num_randomaly = rnd.Next(1, Type_WEaponds.Length);

                    Weapons weapon;
                    switch (num_randomaly)
                    {
                        case 0:
                            weapon = new Rifle_AK47();
                            break;
                        case 1:
                            weapon = new Rifle_M16();
                            break;
                        case 2:
                            weapon = new Gun();
                            break;
                        case 3:
                            weapon = new knife();
                            break;
                        default:
                            weapon = new knife(); // גיבוי
                            break;
                    }

                    t.add_weapend(weapon);
                }


                result.Add(t);
            }

            return result;
        }


    }
}
