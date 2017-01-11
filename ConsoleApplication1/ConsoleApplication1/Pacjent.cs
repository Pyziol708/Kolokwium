using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Pacjent : Osoba
    {
        private int wiek;
        private string choroba;

        public Pacjent(string imieNazwisko, int wiek, string choroba) : base(imieNazwisko)
        {
            this.wiek = wiek;
            this.choroba = choroba;
        }

        public override string ToString()
        {
            return string.Format("Pacjent, imię i nazwisko: {0}, wiek {1}, choroba: {2}.", this.imieNazwisko, this.wiek, this.choroba);
        }
    }
}
