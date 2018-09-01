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
        string featuresOfCorrectGrade;

        public Toolbox(Student student)
        {
            this.student = student;
            ConstructFeaturesOfCorrectGradeInfo();
        }
        
        void ConstructFeaturesOfCorrectGradeInfo()
        {
            if (student.gradeHasPlusAndMinus == true)
                featuresOfCorrectGrade = "Prawidłowa ocena to liczba od 1 do 6 opcjonalnie zawierająca po swojej prawej stronie plus bądź minus (np. 5+ lub 4-).";
            else if (student.gradeHasPlusAndMinus == false)
                featuresOfCorrectGrade = "Prawidłowa ocena to liczba od 1 do 6.";
        }

        public void TemporaryUnavaible(){
            Console.Clear();
            Console.WriteLine("Ta funkcja jest tymczasowo niedostępna.");
            Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
        
        public bool HandleMenuInput()
        {
            char input = Console.ReadKey().KeyChar;
            switch (input){
                case '1':
                    DisplayGrades();
                    break;
                case '2':
                    HandleGradeAdding();
                    break;
                case '3':
                    HandleGradeChanging();
                    break;
                case '4':
                    HandleGradeDeleting();
                    break;
                case '5':
                    TemporaryUnavaible();
                    //student.DrawSettingsMenu();
                    break;
                case '6':
                    Environment.Exit(0);
                    break;
            }
            return true;
        }

        public void DisplayGrades()
        {
            Console.Clear();

            float overallAverage = 0;
            int i = 0;

            foreach (KeyValuePair<string, List<string>> keyValuePair in student.GetGradesDictionary())
            {
                float subjectAverage = 0;
                int j = 0;

                Console.Write(keyValuePair.Key + ": ");
                foreach (string grade in keyValuePair.Value)
                {
                    subjectAverage += ConvertGradeToFloat(grade);
                    j++;

                    Console.Write(grade + ", ");
                }
                subjectAverage /= j;
                if (subjectAverage > 0) Console.Write("Średnia: " + Math.Round(subjectAverage, 2) + "\n");
                else Console.Write("    Średnia: Brak\n");

                if (subjectAverage > 0)
                {
                    overallAverage += subjectAverage;
                    i++;
                }
            }

            overallAverage /= i;

            Console.WriteLine("\nŚrednia: " + Math.Round(overallAverage, 2));
            Console.ReadKey();
        }
        public void HandleGradeAdding()
        {
            Console.Clear();
            Console.Write("Wpisz nazwę przedmiotu, z którego dostałeś ocenę: ");

            string subject = Console.ReadLine();
            if (student.GetGradesDictionary().ContainsKey(subject))
            {
                Console.Clear();
                Console.WriteLine(featuresOfCorrectGrade);
                Console.Write("Wpisz ocenę, którą chcesz dodać: ");

                string fullGrade = Console.ReadLine();
                if(IsGradeOk(fullGrade)){
                    student.AddGrade(subject, fullGrade);
                    Console.WriteLine("Pomyślnie dodano ocenę!");
                }
                else
                    Console.WriteLine("Wpisana ocena jest nieprawidłowa! (" + fullGrade + ")");
            }
            else Console.WriteLine("Taki przedmiot nie istnieje na twojej liście!");

            Console.ReadKey();
        }
        public void HandleGradeChanging()
        {
            Console.Clear();
            Console.Write("Wpisz nazwę przedmiotu, w którym chcesz poprawić ocenę: ");
            string subject = Console.ReadLine();

            if (student.GetGradesDictionary().ContainsKey(subject))
            {
                Console.Clear();
                Console.WriteLine(featuresOfCorrectGrade);
                Console.Write("Wpisz ocenę, którą chcesz poprawić: ");
                string oldGrade = Console.ReadLine();

                if (student.GetGradesDictionary()[subject].Contains(oldGrade))
                {
                    Console.Write("Wpisz poprawioną ocenę: ");
                    string newGrade = Console.ReadLine();
                    if (IsGradeOk(newGrade))
                    {
                        student.ChangeGrade(subject, oldGrade, newGrade);
                        Console.WriteLine("Pomyślnie poprawiono ocenę z " + oldGrade + " na " + newGrade);
                    }
                    else Console.WriteLine("Wpisana ocena jest nieprawidłowa! (" + newGrade + ")");
                }
                else Console.WriteLine("Podana ocena nie istnieje w dzienniku! (" + oldGrade + ")");
            }
            else Console.WriteLine("Taki przedmiot nie istnieje na twojej liście!");

            Console.ReadKey();
        }
        public void HandleGradeDeleting()
        {
            Console.Clear();
            Console.Write("Wpisz nazwę przedmiotu, z którego chcesz usunąć ocenę: ");
            string subject = Console.ReadLine();

            if (student.GetGradesDictionary().ContainsKey(subject))
            {
                Console.Clear();
                Console.WriteLine(featuresOfCorrectGrade);
                Console.Write("Wpisz ocenę, którą chcesz usunąć: ");
                string gradeToDelete = Console.ReadLine();

                if (student.GetGradesDictionary()[subject].Contains(gradeToDelete))
                {
                    student.DeleteGrade(subject, gradeToDelete);
                    Console.WriteLine("Pomyślnie usunięto ocenę! (" + gradeToDelete + ")");
                }
                else Console.Write("Podana ocena nie istnieje w dzienniku! (" + gradeToDelete + ")");
            } else Console.WriteLine("Taki przedmiot nie istnieje!");

            Console.ReadKey();
        }

        public bool IsGradeOk(string fullGrade)
        {
            if (student.gradeHasPlusAndMinus == false)
            {
                try
                {
                    int gradeValue = Int32.Parse(fullGrade);
                    if (gradeValue < 7 && gradeValue > 0) return true;
                    else return false;
                }
                catch(FormatException)
                {
                    return false;
                }
            }
            else if (student.gradeHasPlusAndMinus == true)
            {
                if (Data.gradesWithPlusAndMinus.Contains(fullGrade)) return true;
                else return false;
            }
            return false;
        }
        public float ConvertGradeToFloat(string gradeToConvert)
        {
            if (student.plusAndMinusWorth == false) return Int32.Parse(gradeToConvert[0].ToString());
            else if(student.plusAndMinusWorth == true)
            {
                float value = Int32.Parse(gradeToConvert[0].ToString());

                if (gradeToConvert.Contains("+")) value += student.plusValue;
                else if (gradeToConvert.Contains("-")) value += student.minusValue;

                return value;

            }
            else return 1;
        }
    }
}
