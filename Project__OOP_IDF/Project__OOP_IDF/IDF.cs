using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project__Analiza
{
    internal class IDF : Organizations_class
    {
        //List<Soldier> Soldiers = new List<Soldier>();
        //List<Weapon> Weapons = new List<Weapon>();
        private IDF(string name, string YearOfEstablishment, string general)
        : base(name, YearOfEstablishment, general)
        {

        }
        //public void ReceiveANewSoldier(Soldier NewSoldier)
        //{
        //    this.Soldiers.Add(NewSoldier);
        //} public void ReceiveANewWeapons(Weapon NewSoldier)
        //{
        //    this.Weapons.Add(NewSoldier);
        //}
    }
}