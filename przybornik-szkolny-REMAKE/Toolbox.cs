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

        public void DrawMenu()
        {
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

        void TemporaryUnavaible()
        {
            Console.Clear();
            Console.WriteLine("Ta funkcja jest tymczasowo niedostępna.");
            Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }

        public bool HandleMenuInput()
        {
            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    DisplayGrades();
                    break;
                case '2':
                    TemporaryUnavaible();
                    //toolbox.DrawAddGradeMenu();
                    break;
                case '3':
                    TemporaryUnavaible();
                    //toolbox.DrawRemoveGradeMenu();
                    break;
                case '4':
                    TemporaryUnavaible();
                    //student.MakeBackup();
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

            Dictionary<string, List<string>> gradesDictionary = student.GetGradesDictionary();
            foreach(KeyValuePair<string, List<string>> phrase in gradesDictionary)
            {
                string subject = phrase.Key;
                List<string> grades = phrase.Value;
                Console.Write(subject + ": ");
                foreach(string grade in grades)
                {
                    Console.WriteLine(grade + ", ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("\nŚrednia: Funkcja tymczasowo niedostępna")
            Console.ReadKey();
        }
    }
}
