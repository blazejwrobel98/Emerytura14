using System;
using System.Text.RegularExpressions;

namespace NewProject
{
    public class Program
    {
        public static readonly int[] eme_age = { 60, 65 };
        public static readonly string[] menu_plec = { "Kobieta", "Mężczyzna" };
        public static User user_data;
        public static void Main(string[] args)
        {
            Console.WriteLine(" Aplikacja Emerytura");
            while (true)
            {
                Console.Clear();
                int value = GlobalMenu.GenerateMenu();
                if (value != 0)
                {
                    Console.Clear();
                    GlobalMenu.Option(value);
                }
                else
                {
                    break;
                }
            }
        }
        public static bool InputCheck(string value)
        {
            Console.Clear();
            if (value.Trim().ToUpper() == "DUPA")
            {
                Console.WriteLine(" Witam Pana :) ");
                return false;
            }
            else
            {
                if (value.Length > 20)
                {
                    Console.WriteLine(" Osiągnięto Limit znaków! ");
                    return false;
                }
                else
                {
                    if ((String.IsNullOrEmpty(value)) == true || (Regex.IsMatch(value, @"[0-9\W]")) == true)
                    {
                        Console.WriteLine(" Wprowadzono błędne dane, spróbuj jeszcze raz :) ");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        public static bool IntCheck(string value)
        {
            Console.Clear();
            if (value.Trim().ToUpper() == "DUPA")
            {
                Console.WriteLine(" Witam Pana :) ");
                return false;
            }
            else
            {
                if (value.Length > 3)
                {
                    Console.WriteLine(" Osiągnięto Limit znaków! ");
                    return false;
                }
                else
                {
                    if ((String.IsNullOrEmpty(value)) == true || (Regex.IsMatch(value, "[^0-9]")) == true)
                    {
                        Console.WriteLine(" Wprowadzono błędne dane, spróbuj jeszcze raz :) ");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        public static string GetData(string value)
        {
            Console.Write($" Podaj {value}: ");
            var temp = Console.ReadLine().Trim();
            return temp;
        }
        public static void Pause()
        {
            Console.WriteLine($"\n Wciśnij dowolny przycisk aby kontynuować...");
            Console.ReadKey();
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
                Console.WriteLine(" Wybierz płeć spośród dostępnych: ");
                for (int i = 0; i < Program.menu_plec.Length; i++)
                {
                    Console.WriteLine($" [{i}] {Program.menu_plec[i]} ");
                }
                string temp = Console.ReadLine();
                if ((Program.IntCheck(temp)) == true)
                {
                    int plec = int.Parse(temp);
                    if ((plec < Program.menu_plec.Length) == true)
                    {
                        return plec;
                    }
                    else
                    {
                        Console.WriteLine(" Wprowadzono błędne dane, spróbuj jeszcze raz :) ");
                        goto start;
                    }

                }
            }
        }
    }

    public class GlobalMenu
    {
        public static readonly string[] Global_menu_elements = { "WYJŚCIE", "Wprowadź DANE", "Wyświetl DANE", "Skasuj DANE", "Sprawdź kiedy EMERYTURA", "Wyświetl USTAWIENIA" };
        public static int GenerateMenu()
        {
            while (true)
            {
            start:
                for (int i = 0; i < Global_menu_elements.Length; i++)
                {
                    Console.WriteLine($" [{i}] {Global_menu_elements[i]} ");
                }
                string temp = Console.ReadLine();

                if ((Program.IntCheck(temp)) == true)
                {
                    int option = int.Parse(temp);
                    if ((option < Global_menu_elements.Length) == true)
                    {
                        return option;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(" Wprowadzono błędne dane, spróbuj jeszcze raz :) ");
                        goto start;
                    }

                }
            }
        }
        public static void Option(int value)
        {
            switch (value)
            {
                case 1:
                    Program.user_data = new User();
                    Program.Pause();
                    break;
                case 2:
                    if (Program.user_data == null)
                    {
                        Console.WriteLine("\n Brak przypisanych wartości!!!\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n Imię: {Program.user_data.imie} \n Nazwisko: {Program.user_data.nazwisko}\n Wiek: {Program.user_data.wiek} \n Płeć: {Program.menu_plec[Program.user_data.plec]}");
                    }
                    Program.Pause();
                    break;
                case 3:
                    Program.user_data = null;
                    Console.WriteLine("\n Dane SKASOWANE!\n");
                    Program.Pause();
                    break;
                case 4:
                    if (Program.user_data == null)
                    {
                        Console.WriteLine("\n Brak przypisanych wartości!!!\n");
                    }
                    else
                    {
                        int do_em = Program.eme_age[Program.user_data.plec] - Program.user_data.wiek;
                        if (do_em > 0)
                        {
                            Console.WriteLine($"\n Do emerytury pozostało ci {do_em}\n");
                        }
                        else if (do_em == 0)
                        {
                            Console.WriteLine("\n Na emeryturę przejdziesz w tym roku\n");
                        }
                        else
                        {
                            Console.WriteLine("\n Jesteś emerytem\n");
                        }
                    }
                    Program.Pause();
                    break;
                case 5:
                    Console.WriteLine("\nLista dostępnych płci: ");
                    foreach (var item in Program.menu_plec)
                    {
                        Console.WriteLine($" {item.ToString()}");
                    }
                    Console.WriteLine("\nWiek emerytalny dla kobiet i mężczyzn: ");
                    for (int i = 0; i < Program.menu_plec.Length; i++)
                    {
                        Console.WriteLine($" {Program.menu_plec[i]} : {Program.eme_age[i]}");
                    }
                    Program.Pause();
                    break;
            }
        }
    }
}
