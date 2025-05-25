using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_idf___;

namespace Project_idf___
{
    internal class Hamas : Organizations_class
    {
        List<Terrorist> terrorists = new List<Terrorist>();
        private Hamas(string name, string YearOfEstablishment, string general)
        : base(name, YearOfEstablishment, general)
        { }

            public void ReceiveANewterrorists(Terrorist NewTerrorist)
        {
            this.terrorists.Add(NewTerrorist);
        }
    }
}