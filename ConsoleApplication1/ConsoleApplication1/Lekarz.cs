using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Lekarz : Osoba
    {
        private string specjalnosc;

        public Lekarz(string imieNazwisko, string specjalnosc) : base(imieNazwisko)
        {
            this.specjalnosc = specjalnosc;
        }

        public override string ToString()
        {
            return string.Format("Lekarz, imię i nazwisko: {0}, specjalność: {1}.", this.imieNazwisko, this.specjalnosc);
        }
    }
}
