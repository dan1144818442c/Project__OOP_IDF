using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project__Analiza
{
    abstract class Organizations_class
    {
        protected string name;
        protected string YearOfEstablishment;
        protected string general;
        protected Organizations_class(string name, string YearOfEstablishment, string general)
        {
            this.name = name;
            this.YearOfEstablishment = YearOfEstablishment;
            this.general = general;

        }
        protected void ChangeGeneral(string general)
        {
            this.general = general;
        }



    }
}