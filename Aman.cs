using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    internal class Aman : Unit
    {
        private List<Data_Message> messages = new List<Data_Message>();
        public Aman(string commandor, string purpose) : base(commandor, purpose)
        {
        }

        public List<Terrorist> MostDangerousTerrorist(Hamas hamas)
        {

            List<Terrorist> terrorists = hamas.get_list_terorist();
            if (terrorists.Count == 0)
            {
                Console.WriteLine("There are no terrorists in Hamas.");
                return null;
            }
            int mostDangerousLevelTerrorist = 0;
            List<Terrorist> mostDangerousTerrorist = new List<Terrorist>();


            foreach (Terrorist terrorist in terrorists)
            {
                if ((mostDangerousLevelTerrorist < terrorist.weaponslevel()) && (terrorist.Get_Status() == "alive"))
                {
                    mostDangerousLevelTerrorist = terrorist.weaponslevel();
                    mostDangerousTerrorist.Clear();
                    mostDangerousTerrorist.Add(terrorist);
                }
                else if ((mostDangerousLevelTerrorist == terrorist.weaponslevel()) && (terrorist.Get_Status() == "alive"))
                {
                    mostDangerousTerrorist.Add(terrorist);
                }

            }
            return mostDangerousTerrorist;


        }

        public void updat_loction(Terrorist terorist ,  Target location, Solider solider)
        {
            if (solider.Get_Rank() < 3)
            {
                Console.WriteLine("Your rank isn't high enough");
            }
            else
            {
               terorist.Last_location = location;
               
                string current_time = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                terorist.location[current_time] = location;
            }
        }

        public Data_Message AddMessage(Terrorist terrorist)
        {
            Data_Message messege = new Aman.Data_Message(terrorist);
            messages.Add(messege);
            return messege;
        }



        public List<Terrorist> get_terorist_by(Hamas hamas)

        {
            Console.WriteLine("Search terrorist by:");
            Console.WriteLine("1 - Rank");
            Console.WriteLine("2 - Status");
            Console.WriteLine("3 - Risk Level");
            Console.WriteLine("4 - Has Weapons?");
            Console.WriteLine("5 - Last Known Location");
            Console.WriteLine("6 - full name ");
            Console.Write("Choose option (1-6): ");
            string choice = Console.ReadLine();

            List<Terrorist> results = new List<Terrorist>();
            List<Terrorist> terrorists = hamas.get_list_terorist();
            switch (choice)
            {
                case "1": // חיפוש לפי דרגה
                    Console.Write("Enter rank (0-5): ");

                    if (int.TryParse(Console.ReadLine(), out int rank))
                    {
                        foreach (Terrorist t in terrorists)
                        {
                            if (t.Get_Rank() == rank)
                                results.Add(t);
                        }
                    }
                    break;

                case "2": // חיפוש לפי סטטוס (alive/dead)
                    Console.Write("Enter status (alive/dead): ");
                    string status = Console.ReadLine();
                    foreach (var t in terrorists)
                    {
                        if (t.Get_Status() == status)
                            results.Add(t);
                    }
                    break;

                case "3": // חיפוש לפי רמת סיכון
                    Console.Write("Enter minimum risk level: ");
                    if (int.TryParse(Console.ReadLine(), out int minRisk))
                    {
                        foreach (var t in terrorists)
                        {
                            if (t.weaponslevel() >= minRisk)
                                results.Add(t);
                        }
                    }
                    break;

                case "4": // חיפוש לפי האם יש נשקים
                    Console.Write("Has weapons? (yes/no): ");
                    string answer = Console.ReadLine();
                    foreach (var t in terrorists)
                    {
                        bool has = t.Get_Weapons().Count > 0;
                        if ((answer == "yes" && has) || (answer == "no" && !has))
                            results.Add(t);
                    }
                    break;

                case "5": // חיפוש לפי מיקום אחרון
                    Console.Write("Enter city or area name: ");
                    string area = Console.ReadLine();
                    foreach (var t in terrorists)
                    {
                        Target last = t.Last_location;
                        if (last != null && last.Name == area) // נניח של־Target יש Name
                            results.Add(t);
                    }
                    break;

                case "6":
                    Console.WriteLine("Enter first name");
                    string first_name = Console.ReadLine();
                    Console.WriteLine("Enter last name");
                    string last_name = Console.ReadLine();
                    foreach (Terrorist t in terrorists)
                    {
                        if (t.Get_Full_Name() == first_name + " " + last_name)
                        {
                            results.Add(t);
                        }
                    }
                    break;

            

            default:
                    Console.WriteLine("Invalid choice.");
            break;
        }

            return results;
        }



    public class Data_Message
    {
        public string CurrentTime { get; }
        public Target CurrentLocation { get; }
        public Dictionary<string, object> Data_terorist { get; }
        internal Data_Message(Terrorist terrorist)
        {
            CurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            CurrentLocation = terrorist.Last_location;
            Data_terorist = terrorist.GEt_data_Terorist();
        }


        public object[] Get_data_from_messege(Data_Message messege)
        {
            object[] data = new object[3];
            data[0] = messege.CurrentTime;
            data[1] = messege.CurrentLocation;
            data[3] = messege.Data_terorist;
            return data;

        }





        public void PrintFullTerroristInfo()
        {

            Console.WriteLine($"--- Message @ {CurrentTime:O}, Location: {CurrentLocation}");
            Console.WriteLine($"First Name : {Data_terorist["Firstname"]}");
            Console.WriteLine($"Last  Name : {Data_terorist["Lastname"]}");
            Console.WriteLine($"Age        : {Data_terorist["Age"]}");
            Console.WriteLine($"Rank       : {Data_terorist["Rank"]}");
            Console.WriteLine($"Status     : {Data_terorist["Status"]}");
            Console.WriteLine($"Risk level : {Data_terorist["RiskLevel"]}");

            Console.WriteLine("Weapons    :");

            if (Data_terorist["Weapons"] is List<Weapons> weaponsList)
            {
                foreach (var w in weaponsList)
                    Console.WriteLine($"  - {w}");
            }
            else
            {
                Console.WriteLine("No weapons data.");
            }


            Console.WriteLine("Locations  :");
            if (Data_terorist["Location"] is IDictionary<string, Target> locs)
            {
                foreach (var kv in locs)
                    Console.WriteLine($"  • {kv.Key:O} ? {kv.Value}");
            }

            Console.WriteLine($"Last Known Location: {Data_terorist["LastLocation"]}");
            Console.WriteLine(new string('-', 40));
        }
    }

}
}

