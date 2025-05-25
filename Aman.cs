using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    internal class Aman:Unit
    {
        //List<Person> peoples;
        private List<Data_Message> messages = new List<Data_Message>();
        public Aman(string commandor, string purpose) : base(commandor, purpose)
        {
        }
        public Data_Message AddMessage(Terrorist terrorist)
        {
            Data_Message messege = new Aman.Data_Message(terrorist);
            messages.Add(messege);
            return messege;
        }

      
        public class Data_Message
        {
            public string CurrentTime { get; }
            public Target CurrentLocation { get; }
            public List<object> Data_terorist { get; }
            internal Data_Message(Terrorist terrorist)
            {
                CurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                CurrentLocation = terrorist.Get_Last_Location();
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


            //public 


        
            public void PrintFullTerroristInfo()
            {
                Console.WriteLine($"--- Message @ {CurrentTime:O}, Location: {CurrentLocation}");
                Console.WriteLine($"First Name : {Data_terorist[0]}");
                Console.WriteLine($"Last  Name : {Data_terorist[1]}");
                Console.WriteLine($"Age        : {Data_terorist[2]}");
                Console.WriteLine($"Rank       : {Data_terorist[3]}");
                Console.WriteLine($"Status     : {Data_terorist[4]}");

                Console.WriteLine("Weapons    :");
                if (Data_terorist[5] is IEnumerable<Weapons> weaps)
                {
                    foreach (var w in weaps)
                        Console.WriteLine($"  - {w}");
                }

                Console.WriteLine("Locations  :");
                if (Data_terorist[6] is IDictionary<DateTime, string> locs)
                {
                    foreach (var kv in locs)
                        Console.WriteLine($"  • {kv.Key:O} ? {kv.Value}");
                }

                Console.WriteLine($"Last Known Location: {Data_terorist[7]}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}

        
