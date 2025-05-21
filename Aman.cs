using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project__Analiza;

namespace Project_idf___
{
    internal class Aman:Unit
    {
        //List<Person> peoples;
        private List<Data_Message> messages = new List<Data_Message>();
        public Aman(string commandor, string purpose) : base(commandor, purpose)
        {
        }
        public void AddMessage(Terrorist terrorist)
        {
            messages.Add(new Data_Message(terrorist));
        }

      
        private class Data_Message
        {
            public DateTime CurrentTime { get; }
            public string CurrentLocation { get; }

            public Data_Message(Terrorist terrorist)
            {
                CurrentTime = DateTime.Now;
                CurrentLocation = terrorist.Get_Last_Location();
            }
        }

        
    }
}
