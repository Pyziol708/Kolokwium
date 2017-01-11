using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Przychodnia : IPrzychodnia
    {
        private Lekarz lekarz;
        private Stack<Pacjent> pacjenci = new Stack<Pacjent>();

        public void UstawLekarza(string imieNaziwsko, string specjalnosc)
        {
            this.lekarz = new Lekarz(imieNaziwsko, specjalnosc);
        }

        public void ZapiszDoLekarza(string imieNazwisko, int wiek, string choroba)
        {
            this.pacjenci.Push(new Pacjent(imieNazwisko, wiek, choroba));
        }

        public string WykonajPorade()
        {
            Pacjent pacjent;
            try
            {
                pacjent = this.pacjenci.Pop();
            }
            catch (InvalidOperationException)
            {
                return "Nie wykonano porady! Lista pacjentów jest pusta!";
            }
            return string.Format("Wykonano poradę! {0}.", pacjent.ToString());
        }

        public string WykonajBadanie()
        {
            Pacjent pacjent;
            try
            {
                pacjent = this.pacjenci.Peek();
            }
            catch (InvalidOperationException)
            {
                return "Nie wykonano badania! Lista pacjentów jest pusta!";
            }
            return string.Format("Wykonano badanie! {0}.", pacjent.ToString());
        }

        public int CzasOczekiwania()
        {
            return Convert.ToInt32(Math.Floor(Convert.ToDouble(this.pacjenci.Count / 5)));
        }

        public override string ToString()
        {
            string s = string.Empty;
            s = this.lekarz.ToString();
            s += "\n\nPacjenci oczekujący:";
            foreach (var p in this.pacjenci)
            {
                s += string.Format("\n* {0}", p.ToString());
            }
            s += string.Format("\n\nCzas oczekiwania: {0}", this.CzasOczekiwania());
            return s;
        }

        public void GenerujRaport()
        {
            File.WriteAllText(string.Format("Raport{0}.txt", DateTime.Now.ToString("ddMMyyyyHHmm")), this.ToString());
        }

        public bool CzyLekarz()
        {
            return (this.lekarz != null);
        }
    }
}
