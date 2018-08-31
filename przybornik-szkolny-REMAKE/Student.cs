using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class Student
    {
        string name, surname;

        public bool gradeHasPlusAndMinus;
        public bool plusAndMinusWorth;
        public float plusValue, minusValue;

        public List<string> subjects = new List<string>();
        Dictionary<string, List<string>> grades = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public Student()
        {
            RunFirstStepOfConfig();
            RunSecondStepOfConfig();
            RunThirdStepOfConfig();
            if (gradeHasPlusAndMinus == true) RunFourhtStepOfConfig();
            if (plusAndMinusWorth == true) RunFifthStepOfConfig();

            for (int i = 0; i < subjects.Count; i++)
                grades.Add(subjects[i], new List<string>());
        }

        public Dictionary<string, List<string>> GetGradesDictionary() => grades;

        public void AddGrade(string subject, string fullGrade) => grades[subject].Add(fullGrade);
        public void ChangeGrade(string subject, string oldGrade, string newGrade)
        {
            for (int i = 0; i < grades[subject].Count; i++)
                if (grades[subject][i].Equals(oldGrade))
                {
                    grades[subject][i] = newGrade;
                    break;
                }
        }
        public void DeleteGrade(string subject, string gradeToDelete) => grades[subject].Remove(gradeToDelete);

        void RunFirstStepOfConfig()
        {
            Console.Clear();
            Console.WriteLine("Krok 1: Przedstaw się.");
            Console.WriteLine("Napisz swoje imię i zatwierdź je enterem. ");
            Console.WriteLine("Potem wykonaj tą samą czynność z nazwiskiem");
            Console.WriteLine("");

            name = StudentHelper.GetStudentName();
            surname = StudentHelper.GetStudentSurname();
        }
        void RunSecondStepOfConfig()
        {
            Menu menu = new Menu(Data.stepTwoMenu);

            bool running = true;
            while (running)
            {
                menu.Draw();

                int i = 1;
                foreach (string nameOfSubject in subjects)
                    Console.WriteLine(i++ + ". " + nameOfSubject);

                Console.WriteLine("");
                Console.Write("> ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "COFNIJ":
                        SubjectUndo();
                        break;
                    case "KONIEC":
                        if (subjects.Count > 0)
                        {
                            running = false;
                            Console.Write("Zakończono dodawanie przedmiotów! Naciśnij dowolny klawisz...");
                            Console.ReadKey();
                            break;
                        }
                        else Console.WriteLine("Jeszcze nie dodałeś żadnego przedmiotu!");
                        break;
                    default:
                        if (input == "") break;

                        bool subjectExists = false;
                        foreach (string subject in subjects)
                        {
                            if (input.Equals(subject))
                            {
                                Console.WriteLine("Już dodałeś ten przedmiot! (" + subject + ")");
                                Console.ReadKey();
                                subjectExists = true;
                            }
                        }

                        if (subjectExists == false)
                        {
                            subjects.Add(input);
                            i++;
                        }
                        break;
                }
            }
        }
        void RunThirdStepOfConfig()
        {
        step3:
            Menu menu = new Menu(Data.stepThreeMenu);
            menu.Draw();

            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    gradeHasPlusAndMinus = false;
                    plusAndMinusWorth = false;
                    break;
                case '2':
                    gradeHasPlusAndMinus = true;
                    break;
                default:
                    goto step3;
            }
        }
        void RunFourhtStepOfConfig()
        {
        step4:
            Menu menu = new Menu(Data.stepFourMenu);
            menu.Draw();

            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    plusAndMinusWorth = true;
                    break;
                case '2':
                    plusAndMinusWorth = false;
                    break;
                default:
                    goto step4;
            }
        }
        void RunFifthStepOfConfig()
        {
        step51:
            Console.Clear();
            Console.Write("Wpisz jaką wartość posiada ocena 5+ (np. 5,50): ");
            if (float.TryParse(Console.ReadLine(), out plusValue))
            {
                plusValue -= 5;
                Console.Write("Wpisz jaką wartość posiada ocena 5- (np. 4,75): ");
                if (float.TryParse(Console.ReadLine(), out minusValue)) minusValue -= 5;
                else
                {
                    Console.WriteLine("Podana wartość jest nieprawidłowa!");
                    Console.ReadKey();
                    goto step51;
                }
            }
            else
            {
                Console.WriteLine("Podana wartość jest nieprawidłowa!");
                Console.ReadKey();
                goto step51;
            }
        }
        void SubjectUndo()
        {
            if (subjects.Count > 0)
            {
                subjects.Remove(subjects.Last());
                Console.WriteLine("Pomyślnie usunięto przedmiot!");
            }
            else Console.WriteLine("Jeszcze nie dodałeś żadnego przedmiotu!");
            Console.ReadKey();
        }
    }
}
