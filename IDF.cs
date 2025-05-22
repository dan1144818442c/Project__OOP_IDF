using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_idf___;

namespace Project__Analiza
{
    internal class IDF : Organizations_class
    {
        List<Solider> Soldiers = new List<Solider>();
        List<Attack_options> Weapons = new List<Attack_options>();
        List<Unit> units;
        public IDF(string name, string YearOfEstablishment, string general) : base(name, YearOfEstablishment, general)
        {
            units = new List<Unit>();
        }
        public void ReceiveANewSoldier(Solider NewSoldier)
        {
            this.Soldiers.Add(NewSoldier);
        }
        public void ReceiveANewWeapons(Attack_options NewAttack_options)
        {
            this.Weapons.Add(NewAttack_options);
        }

        public void Add_Unit(Unit NewUnit)
        {
            units.Add(NewUnit);
        }


        public void Show_all_Attach_option()
        {
            foreach (var weapond in Weapons)
            {
                weapond.show_Weapon();
                Console.WriteLine();
            }
        }
    }
}