using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Osoba
    {
        protected string imieNazwisko;
        public Osoba(string imieNazwisko)
        {
            this.imieNazwisko = imieNazwisko;
        }

    }
}
