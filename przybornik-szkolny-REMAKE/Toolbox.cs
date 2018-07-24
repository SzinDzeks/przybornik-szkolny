using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class Toolbox
    {
        Student student;
        public Toolbox(Student student) => this.student = student;

        public void DrawMenu(){
            Console.Clear();
            Console.WriteLine("School tool - menu:");
            Console.WriteLine("");
            Console.WriteLine("1. Wyświetl oceny");
            Console.WriteLine("2. Dodaj ocene");
            Console.WriteLine("3. Popraw ocene");
            Console.WriteLine("4. Wykonaj kopie zapasową");
            Console.WriteLine("5. Ustawienia");
            Console.WriteLine("6. Wyjście z programu");
            Console.WriteLine("");
            Console.Write("Wybór: ");
        }
        
        public void TemporaryUnavaible(){
            Console.Clear();
            Console.WriteLine("Ta funkcja jest tymczasowo niedostępna.");
            Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
        
        public bool HandleMenuInput(){
            char input = Console.ReadKey().KeyChar;
            switch (input){
                case '1':
                    DisplayGrades();
                    break;
                case '2':
                    DrawAddGradeMenu();
                    break;
                case '3':
                    TemporaryUnavaible();
                    //DrawRemoveGradeMenu();
                    break;
                case '4':
                    TemporaryUnavaible();
                    //student.MakeBackup();
                    break;
                case '5':
                    TemporaryUnavaible();
                    break;
                case '6':
                    Environment.Exit(0);
                    break;
            }
            return true;
        }

        public void DisplayGrades(){
            //Pobieranie słownika ocen
            Dictionary<string, List<string>> gradesDictionary = student.GetGradesDictionary();

            Console.Clear();
            //Pętla pobierająca przedmiot i przypisane do niego oceny
            foreach(KeyValuePair<string, List<string>> phrase in gradesDictionary){

                //Wyodrębnianie nazwy przedmiotu i jej wyświetlenie
                string subject = phrase.Key;
                Console.Write(subject + ": ");

                //Wyodrębnienie listy ocen i pętla, która je wyświetla
                List<string> grades = phrase.Value;
                foreach (string grade in grades){
                    Console.WriteLine(grade + ", ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("\nŚrednia: Funkcja tymczasowo niedostępna");
            Console.ReadKey();
        }

        public void DrawAddGradeMenu(){
            //Pobieranie nazwy przedmiotu od użytkownika
            Console.Clear();
            Console.Write("Wpisz nazwę przedmiotu, z którego dostałeś ocenę: ");
            string subject = Console.ReadLine();

            //Sprawdzanie czy podany przedmiot jest na liście
            if (student.GetGradesDictionary().ContainsKey(subject)){

                //Pobieranie oceny do dodania od użytkownika
                Console.Clear();
                if (student.data.gradingType == Data.GradesType.WithPlusAndMinus)
                    Console.WriteLine("Prawidłowa ocena to liczba od 1 do 6 zawierająca po swojej prawej stronie plus bądź minus (np. 5+ lub 4-).\n");
                else if(student.data.gradingType == Data.GradesType.WithoutPlusAndMinus)
                    Console.WriteLine("Prawidłowa ocena to liczba od 1 do 6");
                Console.WriteLine("Wpisz ocenę, którą dostałeś:");

                string fullGrade = Console.ReadLine();
                if(IsGradeOk(fullGrade)){
                    student.AddGrade(subject, fullGrade);
                    Console.WriteLine("Pomyślnie dodano ocenę!");
                    Console.ReadKey();
                }
                else
                    Console.Write("Wpisana ocena jest nieprawidłowa! (" + fullGrade + ")");
            }
            else
                Console.WriteLine("Taki przedmiot nie istnieje na twojej liście!");
        }

        public bool IsGradeOk(string fullGrade){

            //Sprawdzanie rodzaju oceny
            if (student.data.gradingType == Data.GradesType.WithoutPlusAndMinus)
            {
                int gradeValue = Int32.Parse(fullGrade);

                //Sprawdzanie poprawności oceny
                if (fullGrade.Length == 1 && (gradeValue < 7 && gradeValue > 0))
                    return true;
                else
                    return false;
            }
            //Sprawdzanie rodzaju oceny
            else if (student.data.gradingType == Data.GradesType.WithPlusAndMinus)
            {
                int gradeValue = Int32.Parse(fullGrade.ToCharArray()[0].ToString());
                string gradeSymbol = fullGrade.ToCharArray()[1].ToString();

                //Sprawdzanie poprawności oceny
                if ((fullGrade.Length < 3 && fullGrade.Length > 0) && ((gradeValue < 7 && gradeValue > 0) && (gradeSymbol == "+" || gradeSymbol == "-")))
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
