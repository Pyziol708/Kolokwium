using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static Przychodnia przychodnia = new Przychodnia();
        private static bool wyjscie = false;

        static void Main(string[] args)
        {
            do
            {
                while (!przychodnia.CzyLekarz())
                {
                    if (wyjscie)
                        return;

                    UstawLekarza();
                }

                if (wyjscie)
                    break;

                Console.Clear();
                Console.WriteLine("PROGRAM PRZYCHODNIA -> MENU GŁÓWNE");

                PokazMenu();

                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        ZarejestrujPacjenta();
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        WykonajPorade();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        WykonajBadanie();
                        break;
                    case ConsoleKey.Escape:
                        wyjscie = true;
                        break;
                    default:

                        Console.Clear();
                        Console.WriteLine("Nie rozpoznano wyboru.");
                        Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
                        Console.ReadKey();
                        break;
                }
            } while (wyjscie == false);
        }

        static void PokazMenu()
        {
            Console.WriteLine();
            Console.WriteLine("MENU:");
            Console.WriteLine("0: Zarejestruj nowego pacjenta.");
            Console.WriteLine("1: Wykonaj porade.");
            Console.WriteLine("2: Wykonaj badanie.");
            Console.WriteLine();
            Console.WriteLine("Wciśnij klawisz z numerem odpowiadającym temu na liście menu.");
            Console.WriteLine("Bądź wciśnij ESC, aby zakończyć program.");
        }

        static void UstawLekarza()
        {
            string nazwisko = string.Empty;
            string imie = string.Empty;
            string specjalnosc = string.Empty;

            Console.Clear();
            Console.WriteLine("PROGRAM PRZYCHODNIA -> LEKARZ");
            Console.WriteLine();
            Console.Write("Podaj nazwisko lekarza: ");
            nazwisko = Console.ReadLine();
            Console.Write("Podaj imię lekarza: ");
            imie = Console.ReadLine();
            Console.Write("Podaj specjalnosc lekarza: ");
            specjalnosc = Console.ReadLine();

            if (nazwisko.Length == 0 || imie.Length == 0 || specjalnosc.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Cos poszło nie tak. Sprobój ponownie wpisać dane lekarza.");
                Console.WriteLine("Wciśnij klawisz ESC aby wyjść lub inny dowolny aby kontynuować...");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    wyjscie = true;
                return;
            }
            przychodnia.UstawLekarza(string.Format("{0} {1}", imie, nazwisko), specjalnosc);
        }

        static void ZarejestrujPacjenta()
        {
            string nazwisko = string.Empty;
            string imie = string.Empty;
            string choroba = string.Empty;
            int wiek = -1;

            Console.Clear();
            Console.WriteLine("PROGRAM PRZYCHODNIA -> REJESTRACJA PACJENTA");
            Console.WriteLine();
            Console.Write("Podaj nazwisko pacjenta: ");
            nazwisko = Console.ReadLine();
            Console.Write("Podaj imię pacjenta: ");
            imie = Console.ReadLine();
            Console.Write("Podaj wiek pacjenta: ");
            try
            {
                wiek = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("Podano nieprawidłowy wiek pacjenta.", wiek));
                Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Podaj chorobe pacjenta: ");
            choroba = Console.ReadLine();

            if (nazwisko.Length == 0 || imie.Length == 0 || choroba.Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Cos poszło nie tak. Wciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
                return;
            }

            if (wiek < 0 || wiek >= 109)
            {
                Console.WriteLine();
                Console.WriteLine(string.Format("Podano nieprawidłowy wiek pacjenta ({0}).", wiek));
                Console.WriteLine("Musi on mieścić się w przedziale od 0 do 109.");
                Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
                return;
            }

            przychodnia.ZapiszDoLekarza(string.Format("{0} {1}", imie, nazwisko), wiek, choroba);
            Console.WriteLine("Pomyślnie zarejestrowano pacjenta!");
            Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }

        static void WykonajPorade()
        {
            Console.Clear();
            Console.WriteLine("PROGRAM PRZYCHODNIA -> WYKONANIE PORADY");
            Console.WriteLine();

            Console.WriteLine(przychodnia.WykonajPorade());
            Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }

        static void WykonajBadanie()
        {
            Console.Clear();
            Console.WriteLine("PROGRAM PRZYCHODNIA -> WYKONANIE BADANIA");
            Console.WriteLine();

            Console.WriteLine(przychodnia.WykonajBadanie());
            Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
    }
}
