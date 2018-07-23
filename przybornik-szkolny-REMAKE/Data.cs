using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class Data
    {
        public List<string> subjects = new List<string>();
        enum gradesType{ withPlusAndMinus, withoutPlusAndMinus };
        gradesType gradingType;
        bool isPlusAndMinusWorth;

        public bool Prepare()
        {
            //Obsługa uzupełniania listy przedmiotów
            bool running = true;
            while(running)
            {
                Console.Clear();
                Console.WriteLine("Krok 2: Sporządzenie listy przedmitotów. ");
                Console.WriteLine("Wypisz wszystkie swoje przedmioty szkolne, zatwierdzając każdy Enter'em.");
                Console.WriteLine("Aby usunąć ostatnio dodany przedmiot wpisz COFNIJ i zatwierdź Enter'em");
                Console.WriteLine("Gdy skończysz napisz KONIEC i zatwierdź Enter'em.");
                Console.WriteLine();

                int i = 1;
                foreach (string nameOfSubject in subjects)
                {
                    Console.WriteLine(i + ". " + nameOfSubject);
                    i++;
                }

                Console.Write("\n> ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "COFNIJ":
                        if(subjects.Count > 0)
                        {
                            string nazwaPrzedmiotu = subjects.Last();
                            subjects.Remove(nazwaPrzedmiotu);
                            i--;
                            Console.WriteLine("Pomyślnie usunięto przedmiot o nazwie: " + nazwaPrzedmiotu);
                            Console.ReadKey();
                        } else {
                            Console.WriteLine("Jeszcze nie dodałeś żadnego przedmiotu!");
                            Console.ReadKey();
                        }
                        break;
                    case "KONIEC":
                        running = false;
                        Console.Write("Zakończono dodawanie przedmiotów! Naciśnij dowolny klawisz...");
                        Console.ReadKey();
                        break;
                    default:
                        if (input == "") break;

                        string nameOfSubject = "";
                        foreach(string subject in subjects)
                        {
                            if(input.Equals(subject))
                            {
                                nameOfSubject = subject;
                                Console.WriteLine("Już dodałeś ten przedmiot! (" + nameOfSubject + ")");
                                Console.ReadKey();
                                break;
                            }
                        }
                        if (input.Equals(nameOfSubject)) break;

                        subjects.Add(input);
                        i++;
                        break;
                }
            }
            {
                step3:
                Console.Clear();
                Console.WriteLine("Krok 3: Wybranie typu ocen");
                Console.WriteLine("");
                Console.WriteLine("W niektórych placówkach oceny są zapisywane tylko całościowo,");
                Console.WriteLine("w innych są zapisywane z plusami i minusami.");
                Console.WriteLine("Powiedz nam jak jest u ciebie.");
                Console.WriteLine("Wybierz jedną z opcji:");
                Console.WriteLine("");
                Console.WriteLine("1. Oceny tylko całościowe");
                Console.WriteLine("2. Oceny całościowe oraz z plusami i minusami");
                Console.WriteLine("");
                Console.Write("Wybór: ");
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case '1':
                        gradingType = gradesType.withoutPlusAndMinus;
                        break;
                    case '2':
                        gradingType = gradesType.withPlusAndMinus;
                        break;
                    default:
                        goto step3;
                }
            }
            {
                step4:
                Console.Clear();
                Console.WriteLine("Krok 4: Czy plusy i minusy są brane pod uwagę przy obliczaniu średnich?");
                Console.WriteLine("Wybierz jedną z opcji:");
                Console.WriteLine("");
                Console.WriteLine("1. Tak");
                Console.WriteLine("2. Nie");
                Console.WriteLine("");
                Console.Write("Wybór: ");
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case '1':
                        isPlusAndMinusWorth = true;
                        break;
                    case '2':
                        isPlusAndMinusWorth = false;
                        break;
                    default:
                        goto step4;
                }

            }
            return true;
        }
    }
}
