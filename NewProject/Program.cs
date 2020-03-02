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
            User user_data = new User();

            Console.WriteLine($"Witaj {user_data.imie} {user_data.nazwisko}!\nMasz {user_data.wiek} lat");
            
            int do_em = eme_age[user_data.plec] - user_data.wiek;
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
        public static bool IntCheck(string value)
        {
            if ((String.IsNullOrEmpty(value)) == true || (Regex.IsMatch(value, "[^0-9]")) == true)
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


    public class User
    {
        public string imie = GetUserData("imie");
        public string nazwisko = GetUserData("nazwisko");
        public int wiek = GetAge();
        public int plec = GetGender();

        private static string GetUserData(string value)
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
        private static int GetAge()
        {
            while (true)
            {
                string temp = Program.GetData("wiek");
                if ((Program.IntCheck(temp)) == true)
                {
                    int wiek = int.Parse(temp);
                    return wiek;
                }
            }
        }
        private static int GetGender()
        {
            while (true)
            {
                start:
                Console.WriteLine("Wybierz płeć spośród dostępnych: ");
                for (int i = 0; i < Program.menu_plec.Length; i++)
                {
                    Console.WriteLine($"[{i}] {Program.menu_plec[i]} ");
                }
                string temp = Console.ReadLine();
                if ((Program.IntCheck(temp)) == true)
                {
                    int plec = int.Parse(temp);
                    if((plec < Program.menu_plec.Length)==true)
                    {
                        return plec;
                    }
                    else
                    {
                        Console.WriteLine("Wprowadzono błędne dane, spróbuj jeszcze raz :) ");
                        goto start;
                    }

                }
            }
        }
    }
    
    public class MainMenu
    {
        public static readonly string[] Main_menu_elements = { "WYJŚCIE", "Wprowadź DANE", "Wyświetl DANE", "Skasuj DANE", "Sprawdź kiedy EMERYTURA","Wyświetl USTAWIENIA" };
    }
}
