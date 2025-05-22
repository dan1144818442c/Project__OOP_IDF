using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    abstract public class Unit
    {
        //Solider Comanndor;
        string commansor;
        string purpose;
        //List<Solider> soliders;
        public Unit(string commandor , string purpose) {
            this.purpose = purpose;
            this.commansor = commandor;
                        
                }
    }
}
