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
        List<string> addGradeMenu = new List<string>();

        public Toolbox(Student student)
        {
            this.student = student;
            ConstructAddGradeMenu();
        }
        
        void ConstructAddGradeMenu()
        {
            if (student.data.gradingType == Data.GradesType.WithPlusAndMinus)
                addGradeMenu.Add("Prawidłowa ocena to liczba od 1 do 6 zawierająca po swojej prawej stronie plus bądź minus (np. 5+ lub 4-).\n");
            else if (student.data.gradingType == Data.GradesType.WithoutPlusAndMinus)
                addGradeMenu.Add("Prawidłowa ocena to liczba od 1 do 6.");
            addGradeMenu.Add("Wpisz ocenę, którą dostałeś: ");
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
                    TemporaryUnavaible();
                    //DrawRemoveGradeMenu();
                    break;
                case '4':
                    TemporaryUnavaible();
                    //student.MakeBackup();
                    break;
                case '5':
                    Environment.Exit(0);
                    break;
            }
            return true;
        }

        public void DisplayGrades()
        {
            Console.Clear();
            foreach(KeyValuePair<string, List<string>> phrase in student.GetGradesDictionary())
            {
                Console.WriteLine(phrase.Key + ": ");

                foreach (string grade in phrase.Value)
                    Console.Write(grade + ", ");
            }

            Console.WriteLine("\nŚrednia: Funkcja tymczasowo niedostępna");
            Console.ReadKey();
        }

        public void HandleGradeAdding()
        {
            Console.Clear();
            Console.Write("Wpisz nazwę przedmiotu, z którego dostałeś ocenę: ");

            string subject = Console.ReadLine();
            if (student.GetGradesDictionary().ContainsKey(subject))
            {
                Menu menu = new Menu(addGradeMenu);
                menu.Draw();

                string fullGrade = Console.ReadLine();
                if(IsGradeOk(fullGrade)){
                    student.AddGrade(subject, fullGrade);
                    Console.WriteLine("Pomyślnie dodano ocenę!");
                }
                else
                    Console.Write("Wpisana ocena jest nieprawidłowa! (" + fullGrade + ")");
            }
            else Console.WriteLine("Taki przedmiot nie istnieje na twojej liście!");

            Console.ReadKey();
        }

        public bool IsGradeOk(string fullGrade)
        {
            if (student.data.gradingType == Data.GradesType.WithoutPlusAndMinus)
            {
                try
                {
                    int gradeValue = Int32.Parse(fullGrade);
                    if (gradeValue < 7 && gradeValue > 0) return true;
                    else return false;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Wpisana ocena jest nieprawidłowa! (" + fullGrade + ")");
                    Console.ReadKey();
                }
            }
            else if (student.data.gradingType == Data.GradesType.WithPlusAndMinus)
            {
                if (Data.gradesWithPlusAndMinus.Contains(fullGrade)) return true;
                else return false;
            }
            return false;
        }
    }
}
