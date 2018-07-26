using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przybornik_szkolny_REMAKE
{
    class ConfigHandler
    {
        Student student;
        public ConfigHandler(Student student) => this.student = student;
        public static void RunStepOneOfConfig() { }
        public static void RunStepTwoOfConfig()
        {
            step2:
            Menu menu = new Menu(Data.stepTwoMenu);
            menu.Draw();

            int i = 1;
            foreach (string nameOfSubject in student.data.subjects)
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
                    Console.Write("Zakończono dodawanie przedmiotów! Naciśnij dowolny klawisz...");
                    Console.ReadKey();
                    RunStepThreeOfConfig();
                    break;
                default:
                    if (input == "") break;

                    string nameOfSubject = "";
                    foreach (string subject in student.data.subjects)
                    {
                        if (input.Equals(subject))
                        {
                            Console.WriteLine("Już dodałeś ten przedmiot! (" + nameOfSubject + ")");
                            Console.ReadKey();
                            nameOfSubject = subject;
                            goto step2;
                        }
                    }

                    student.data.subjects.Add(input);
                    i++;
                    goto step2;
            }
            Console.ReadKey();
            goto step2;
        }
        public static void RunStepThreeOfConfig()
        {
            step3:
            Menu menu = new Menu(Data.stepThreeMenu);
            menu.Draw();

            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    student.data.gradingType = Data.GradesType.WithoutPlusAndMinus;
                    break;
                case '2':
                    student.data.gradingType = Data.GradesType.WithPlusAndMinus;
                    break;
                default:
                    goto step3;
            }
        }
        public static void RunStepFourOfConfig()
        {
            step4:
            Menu menu = new Menu(Data.stepFourMenu);
            menu.Draw();

            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    student.data.isPlusAndMinusWorth = true;
                    break;
                case '2':
                    student.data.isPlusAndMinusWorth = false;
                    break;
                default:
                    goto step4;
            }
        }
        void SubjectUndo()
        {
            if (student.data.subjects.Count > 0)
            {
                student.data.subjects.Remove(student.data.subjects.Last());
                Console.WriteLine("Pomyślnie usunięto przedmiot!");
            }
            else Console.WriteLine("Jeszcze nie dodałeś żadnego przedmiotu!");
        }
    }
}
