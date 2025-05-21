using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project__Analiza
{
    internal class Hamas : Organizations_class
    {
        //List<Soldier> Soldiers = new List<Soldier>();
        //List<terrorist> terrorists = new List<terrorist>();
        private Hamas(string name, string YearOfEstablishment, string general)
        : base(name, YearOfEstablishment, general)
        {

        }
        //    public void ReceiveANewSoldier(Soldier NewSoldier)
        //    {
        //        this.Soldiers.Add(NewSoldier);
        //    }
        //    public void ReceiveANewterrorists(terrorist NewSoldier)
        //    {
        //        this.terrorists.Add(NewSoldier);
        //    }
    }
}