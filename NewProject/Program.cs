using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NewProject
{
    public class Program
    {
        public static readonly int[] eme_age = { 60, 65 };
        public static readonly string[] menu_plec = {"Kobieta", "Mężczyzna"};
        static void Main(string[] args)
        {
            Console.WriteLine("Aplikacja Emerytura");

            firstname:
            string imie = GetData("imie");
            if ((InputCheck(imie)) == false)
            {
                goto firstname;
            }

            lastname:
            string nazwisko = GetData("nazwisko");
            if ((InputCheck(nazwisko)) == false)
            {
                goto lastname;
            }

            Console.WriteLine($"Witaj {imie} {nazwisko}");
            Console.Write("Podaj wiek: ");
            int wiek = int.Parse(Console.ReadLine());
            Console.WriteLine("Wybierz płeć spośród dostępnych: ");
            for(int i = 0; i < menu_plec.Length; i++)
            {
                Console.WriteLine($"[{i}] {menu_plec[i]} ");
            }
            int plec = int.Parse(Console.ReadLine());
            int do_em = eme_age[plec] - wiek;
            if (do_em > 0)
            {
                Console.WriteLine($"Do emerytury pozostało ci {do_em}");
            }
            else if(do_em == 0)
            {
                Console.WriteLine("Na emeryturę przejdziesz w tym roku");
            }
            else
            {
                Console.WriteLine("Jesteś emerytem");
            }
        }
        public static bool InputCheck(string value)
        {
            if ((String.IsNullOrEmpty(value)) == true || (Regex.IsMatch(value, "[0-9]")) == true)
            {
                Console.WriteLine("Wprowadzono błędne dane, spróbuj jeszcze raz :) ");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GetData(string value)
        {
            Console.Write($"Podaj {value}: ");
            var temp = Console.ReadLine().Trim();
            return temp;
        }
    }
    class User
    {
        string imie = "";
        string nazwisko = "";
        int wiek = 0;
        
        public User()
        {
            User myUser = new User();
            myUser.imie = GetData("imie");
            myUser.nazwisko = GetData("nazwisko");
            myUser.wiek = GetAge();
        }
        static string GetData(string value)
        {
            while (true)
            {
                string temp = Program.GetData($"{value}");
                if ((Program.InputCheck(temp)) == true)
                {
                    return temp;
                }
            }
        }
        static int GetAge()
        {
            while (true)
            {
                string temp = Program.GetData("wiek");
                int wiek = int.Parse(temp);
                return wiek;
            }
        }
    }
}
