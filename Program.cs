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


        static async Task Main(string[] args)
        {
            List<Terrorist> terrorists = GenerateRandomTerrorists(5);
            List<Solider> soliders = GenerateRandomSoldiers(5);



            IDF IDf = new IDF("Israel defend forsec", "1948", "Alof Zamir");
            F16_Fighter_Jet F16_1 = new F16_Fighter_Jet("Adir 2", 3, 480, "pilot - Dan");
            Hermes__460__Zik__ hermes__460__Zik__1 = new Hermes__460__Zik__("Hemrmes GAZA", 3, 125, "remote controlled");
            M109_Artillery m109_Artillery_1 = new M109_Artillery("M109_Artillery - Lbanon", 40, 60, "5 Solider");
            Aman aman = new Aman("Meir Libro", "Intelligence and cyber operations in the IDF"); IDf.Add_Unit(aman);


            IDf.ReceiveANewWeapons(m109_Artillery_1);
            IDf.ReceiveANewWeapons(hermes__460__Zik__1);
            IDf.ReceiveANewWeapons(F16_1);

            foreach (Terrorist terrorist1 in terrorists)
            {
                var msg = aman.AddMessage(terrorist1);
                msg.PrintFullTerroristInfo();
            }


            IDf.Show_all_Attach_option();
            
            Target boilding1 = new Building("gata city 3", "abi 3.5987");

            aman.updat_loction(terrorists[0], boilding1, soliders[0]);
            //F16_1.Attack(boilding1, terrorists[0]);
            //terrorists[0].show_data_terorist();
            //Console.WriteLine(terrorists[0].Get_Status());

            Hamas hamas = new Hamas("hamas Gaza", "2007", "Sinuar");
            foreach (Terrorist terrorist in terrorists)
            {
                hamas.ReceiveANewterrorists(terrorist);
            }



            //List<Terrorist> chois_list = aman.get_terorist_by(hamas);
            //foreach (Terrorist t in chois_list)
            //{
            //    t.show_data_terorist();
            //}

            ////IDf.Show_all_Attach_option();
            List<Terrorist> Lisr_danger_terorist = aman.MostDangerousTerrorist(hamas);
            //foreach (Terrorist t in Lisr_danger_terorist)
            //{
            //    t.show_data_terorist();
            //}
            //foreach(Solider s in soliders)
            //{
            //    s.show_Solider();
            //}

            //Console.WriteLine(hamas.get_list_terorist().Count);

            hermes__460__Zik__1.Attack( Lisr_danger_terorist[0]);
            //Lisr_danger_terorist[0].show_data_terorist();
            //foreach (Terrorist terrorist1 in terrorists)
            //{
            //    var msg = aman.AddMessage(terrorist1);
            //    msg.PrintFullTerroristInfo();
            //}
            //while (true)
            //{
            //    Console.WriteLine("הכנס מה שאתה רוצה לשאול");
            //    await GeminiExecutor.RunAsync();
            //}

        ShowMainMenu(soliders, terrorists, hamas , aman , IDf);

        }
        static List<Solider> GenerateRandomSoldiers(int count)
        {
            var rnd = new Random();
            string[] firstNames = { "Dan", "Yossi", "Avi", "Ron", "Tomer" };
            string[] lastNames = { "Cohen", "Levi", "Mizrahi", "Katz", "Bar-On" };
            List<Solider> soldiers = new List<Solider>();

            for (int i = 0; i < count; i++)
            {
                string first = firstNames[rnd.Next(firstNames.Length)];
                string last = lastNames[rnd.Next(lastNames.Length)];
                int age = rnd.Next(18, 45);
                int rank = rnd.Next(1, 10); // נגיד דרגות מ־1 עד 9

                Solider soldier = new Solider(first, last, age, rank);
                soldiers.Add(soldier);
            }

            return soldiers;
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

        static void ShowMainMenu(List<Solider> soldiers, List<Terrorist> terrorists, Hamas hamas, Aman aman , IDF idf)
        {
            while (true)
                
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1 - Show list of soldiers");
                Console.WriteLine("2 - Show Hamas terrorists");
                Console.WriteLine("3 - Terrorist selection menu");
                Console.WriteLine("4 - spesific terorist");
                Console.WriteLine("5 - to attack");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Soldiers ---");
                        foreach (var s in soldiers)
                            s.show_Solider();
                        break;

                    case "2":
                        Console.WriteLine("\n--- Hamas Terrorists ---");
                        foreach (var t in hamas.get_list_terorist())
                            t.show_data_terorist();
                        break;

                    case "3":
                        Console.WriteLine("\nSelect criterion:");
                        Console.WriteLine("1 - Age above 30");
                        Console.WriteLine("2 - Rank above 3");
                        Console.Write("Enter your choice: ");
                        string subChoice = Console.ReadLine();

                        List<Terrorist> filtered = new List<Terrorist>();
                        if (subChoice == "1")
                            filtered = hamas.get_list_terorist().Where(t => t.Get_Age() > 30).ToList();
                        else if (subChoice == "2")
                            filtered = hamas.get_list_terorist().Where(t => t.Get_Rank() > 3).ToList();
                        else
                            Console.WriteLine("Invalid choice");

                        Console.WriteLine("\n--- Filtered Terrorists ---");
                        foreach (var t in filtered)
                            t.show_data_terorist();
                        break;

                    case "4":
                        List<Terrorist> list =  aman.get_terorist_by(hamas);
                        foreach (var t in list)
                        {
                            t.show_data_terorist();
                        }
                        return;
                    case "5":
                        Menu_Static.HandleAttackMenu(idf.GetWeapons() , terrorists );
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;

                
                }
                
            }
        }


    }
}
