using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_idf___.Aman;

namespace Project_idf___
{
    internal class Program
    {


        static void Main(string[] args)
        {
            List<Terrorist> terrorists = GenerateRandomTerrorists(5);
           


            IDF IDf =  new IDF("Israel defend forsec", "1948" , "Alof Zamir" );
            F16_Fighter_Jet F16_1 = new F16_Fighter_Jet("Adir 2", 3, 480, "pilot - Dan");
            Hermes__460__Zik__ hermes__460__Zik__1 = new Hermes__460__Zik__("Hemrmes GAZA", 3, 125, "remote controlled");
            M109_Artillery m109_Artillery_1 = new M109_Artillery("M109_Artillery - Lbanon", 40, 60, "5 Solider");
            Aman aman = new Aman("Meir Libro", "Intelligence and cyber operations in the IDF");           IDf.Add_Unit(aman);

            
           IDf.ReceiveANewWeapons(m109_Artillery_1);
           IDf.ReceiveANewWeapons(hermes__460__Zik__1);
           IDf.ReceiveANewWeapons(F16_1);
            foreach(Terrorist terrorist1 in terrorists)
            {
              var msg =  aman.AddMessage(terrorist1);
                msg.PrintFullTerroristInfo();
            }

            IDf.Show_all_Attach_option();
            Solider solidet1 = new Solider("dan", "sofer", 28, 5);
            Target boilding1 = new Building("gata city 3" , "abi 3.5987");
            
            terrorists[0].updat_loction(boilding1 , solidet1);
            F16_1.Attack(boilding1 , terrorists[0]);
            Console.WriteLine(terrorists[0].Get_Status());


           

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
                            weapon = new knife();
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
