using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class Program
    {
        const int men_em = 65;
        const int wom_em = 60;
        static void Main(string[] args)
        {
            Console.WriteLine("Aplikacja Emerytura");
            Console.Write("Podaj imie: ");
            string imie = Console.ReadLine().Trim();
            Console.Write("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine().Trim();
            Console.WriteLine($"Witaj {imie} {nazwisko}");
            Console.Write("Podaj wiek: ");
            int wiek = int.Parse(Console.ReadLine());
            Console.WriteLine("Wybierz płeć spośród dostępnych: ");
            Console.WriteLine("[0] KOBIETA ");
            Console.WriteLine("[1] MĘŻCZYZNA ");
            int plec = int.Parse(Console.ReadLine());
            switch (plec)
            {
                case 0:
                    if (wiek >= wom_em)
                    {
                        Console.WriteLine("Jesteś EMERYTEM");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Osiągniesz wiek emerytalny za {wom_em - wiek} lat");
                        break;
                    }
                case 1:
                    if (wiek >= men_em)
                    {
                        Console.WriteLine("Jesteś EMERYTEM");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Osiągniesz wiek emerytalny za {men_em - wiek} lat");
                        break;
                    }
            }
        }
    }
}
