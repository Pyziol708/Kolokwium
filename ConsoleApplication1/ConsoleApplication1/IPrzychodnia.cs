using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IPrzychodnia
    {
        void UstawLekarza(string imieNaziwsko, string specjalnosc);
        void ZapiszDoLekarza(string imieNazwisko, int wiek, string choroba);
        string WykonajPorade();
        string WykonajBadanie();
        int CzasOczekiwania();
        void GenerujRaport();
    }
}
