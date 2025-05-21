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
        public Aman(string commandor, string purpose) : base(commandor, purpose)
        {
        }

        private class Data_Messege
        {
            DateTime corrent_time;
            public Data_Messege(Terrorist Terrorist)
            {
                corrent_time = DateTime.Now;
                corrent__loction = Terrorist.loction;
                
            }
        }
    }
}
