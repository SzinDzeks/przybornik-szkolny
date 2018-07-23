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
        string filePath;
        Dictionary<string, List<string>> grades = new Dictionary<string, List<string>>();
        Data data;
        StudentHelper studentHelper;

        public bool Prepare()
        {
            Console.Clear();
            Console.WriteLine("Krok 1: Przedstaw się.");
            Console.WriteLine("Napisz swoje imię i zatwierdź je enterem. ");
            Console.WriteLine("Potem wykonaj tą samą czynność z nazwiskiem");
            Console.WriteLine("");

            studentHelper = new StudentHelper();
            name = studentHelper.GetStudentName();
            surname = studentHelper.GetStudentSurname();

            //Tworzenie listy przedmiotów
            data = new Data();
            if (!data.Prepare()) return false;

            //Przygotowywanie listy ocen do zapisu
            for (int i = 0; i < data.subjects.Count; i++)
                grades.Add(data.subjects[i], new List<string>());

            //Generowanie ścieżki zapisu plików     //TODO: Sprawdzić, czy jest jakieś lepsze rozwiązanie
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\School Tool";
            FileHelper.CreateDirectoryIfNotExists(filePath);

            filePath += "\\students";
            FileHelper.CreateDirectoryIfNotExists(filePath);

            filePath += "\\" + name + "_" + surname;
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Exists) fi.Create();

            return true;
        }
    }
}
